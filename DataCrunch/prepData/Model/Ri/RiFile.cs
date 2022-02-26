using Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Core;

namespace Model
{
    public class RiFile : AFile, IContent
    {
        #region inteface core

        public RiDescrFileDataSource riDescrFileDataSource { get; private set; }
        public List<RiDescrFile> riDescrFiles { get; set; }
        #endregion
        #region public properties

        public String DescrFilePath { get; private set; }

        public String DataFilePath { get; private set; }

        public List<RiDescrFileData> DescrFileData { get; private set; }

        public Dictionary<int, RiIndividu> RiIndividu { get; private set; }
        
        #endregion

        #region conctructor
        public RiFile(String descrFilePath, String dataFilePath, BackgroundWorker Worker) : base(Worker)
        {
            DescrFilePath = descrFilePath;

            DataFilePath = dataFilePath;

            DescrFileData = new List<RiDescrFileData>();

            RiIndividu = new Dictionary<int, RiIndividu>();

            ReadFile();

            riDescrFileDataSource = new RiDescrFileDataSource(DescrFilePath);
            riDescrFiles = riDescrFileDataSource.Provider();
        }
        #endregion

        #region operations

        public int GetContentSize()
        {
            return RiIndividu.Count;
        }

        private void LoadDescrFile()
        {
            if (String.IsNullOrEmpty(DescrFilePath))
                throw new Exception("Description file is vide");
            
            //Charger le fichier directement
            string[] l_lines = File.ReadAllLines(this.DescrFilePath);
            for (int i = 1; i < l_lines.Length; i++)
            {
                string[] sous_lines = l_lines[i].Split(';');
                RiDescrFileData.DataType type;
                int supportId = -1;
                if (sous_lines[3].ToUpper() == "ID")
                {
                    type = RiDescrFileData.DataType.Individual;
                }
                else
                {
                    type = RiDescrFileData.DataType.Support;
                    supportId = int.Parse(sous_lines[3].Substring(1));
                }
                DescrFileData.Add(new RiDescrFileData(int.Parse(sous_lines[0]), int.Parse(sous_lines[1]), supportId, type));
            }

            /*Charger le fichier par l'interface core, Réduire le couplage*/

        }

        private void LoadDataFile()
        {
            if (String.IsNullOrEmpty(this.DataFilePath) || this.DescrFileData.Count == 0)
                throw new Exception("Data file is vide");

            int sum = this.DescrFileData.Count;
            string[] l_lines = File.ReadAllLines(this.DataFilePath);
            for (int i = 0; i < l_lines.Length; i++)
            {
                String individualId = "";
                for (int j = 0; j < this.DescrFileData.Count; j++)
                {
                    int beginPos = DescrFileData[j].BeginPos;
                    int endPos = DescrFileData[j].EndPos;
                    String value = l_lines[i].Substring(beginPos  - 1, endPos - beginPos + 1);

                    if (DescrFileData[j].IsIndividual())
                        individualId = value.Trim();
                    else if (DescrFileData[j].IsSupport())
                    {
                        if (individualId != "")
                        {
                            int supportId = DescrFileData[j].SupportCode;
                            double ri =  Double.Parse(value);
                            if (ri == 0.0)
                                continue;
                            // ona ajoute les ri pour l'individu et le support

                            if (!this.RiIndividu.ContainsKey(supportId))
                                 this.RiIndividu.Add(supportId, new RiIndividu(individualId, ri));
                             else
                                 this.RiIndividu[supportId].Add(individualId, ri);

                        }
                    }
                }
            }

        }

        public override void ReadFile()
        {
            _Worker.ReportProgress(1, new DataLogs(LogType.None, "traitement en cours..."));

            LoadDescrFile();

            LoadDataFile();
        }
        public override void ExportFile()
        {
           

            if (RiIndividu.Count == 0)
                return;

            //string InputFileName = Path.GetFileName(this._dataFilePath);

            //this.OutPath += InputFileName.Split('.')[0] + "_supp_";
            this._OutputPathName = FilePathManager.getInstance().getPathName(DataType.Ri, this.DescrFilePath);
            this._OutputFileName = FilePathManager.getInstance().getFileName(DataType.Ri, this.DescrFilePath);

            if (!Directory.Exists(this._OutputPathName))
            {
                Directory.CreateDirectory(this._OutputPathName);
            }
            //String OutPath = @"./OutFile/ONE NEXT 2020_support_";

            foreach (KeyValuePair<int, RiIndividu> item in RiIndividu)
            {
                try
                {
                    using (var writer = new StreamWriter(_OutputFileName + item.Key + ".csv"))
                    {
                       _Worker.ReportProgress(1, new DataLogs(LogType.None, String.Format("{0}.csv est généré ...", _OutputFileName + item.Key)));
                       foreach (KeyValuePair<string, double> data in item.Value.GetRiIndividu())
                       {
                            writer.WriteLine(data.Key + ";" + data.Value);
                       }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        #endregion
    }
}
