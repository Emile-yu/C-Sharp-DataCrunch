using Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using Core;

namespace Model
{
    public class SupportFile : AFile, IContent
    {
        #region private
        private SupportDataSource _supportDataSource;
        #endregion
        #region membres
        //public Dictionary<string, string[]> Supports { get; private set; }

        public Dictionary<int, List<Support>> Supports { get; private set; }
        #endregion

        #region constructor
        public SupportFile(String fileName, BackgroundWorker Worker) : base(fileName, Worker)
        {
            //Supports = new Dictionary<string, string[]>();
            Supports = new Dictionary<int, List<Support>>();
            ReadFile();

        }
        #endregion

        #region operations

        public int GetContentSize()
        {
            return Supports.Count();
        }

        public override void ReadFile()
        {
            if (String.IsNullOrEmpty(this._fileName))
            {
                throw new Exception("File Name is vide"); ;
            }

            _Worker.ReportProgress(1, new DataLogs(LogType.None, "traitement en cours..."));

            //string[] l_lines = File.ReadAllLines(this._fileName).Where(o => !o.Contains("ID")).ToArray();

            //Supports = l_lines.GroupBy(l => l.Split(';')[1]).ToDictionary(o => o.Key, o => o.ToArray());

            _supportDataSource = new SupportDataSource(_fileName);

            Supports = _supportDataSource.Provider().GroupBy(l => l.IdTitre).ToDictionary(o => o.Key, o => o.ToList());
        }

        public override void ExportFile()
        {

            if (String.IsNullOrEmpty(this._fileName))
            {
                throw new Exception("File Name is vide");
            }

            this._OutputPathName = FilePathManager.getInstance().getPathName(DataType.Support, this._fileName);
            this._OutputFileName = FilePathManager.getInstance().getFileName(DataType.Support, this._fileName);
            if (!Directory.Exists(this._OutputPathName))
            {
                Directory.CreateDirectory(this._OutputPathName);
            }


            foreach (KeyValuePair<int, List<Support>> item in Supports)
            //foreach (KeyValuePair<string, string[]> item in Supports)
            {
                _Worker.ReportProgress(1, new DataLogs(LogType.None, String.Format("{0}.csv est en cours de générer ...", this._OutputFileName + item.Key)));

                //File.WriteAllLines(this._OutputFileName + item.Key + ".csv", item.Value);

                _supportDataSource.Writer(this._OutputFileName + item.Key + ".csv", item.Value);
                
                _Worker.ReportProgress(1, new DataLogs(LogType.Success, String.Format("{0}.csv est généré ...", this._OutputFileName + item.Key)));
            }

        }
        
        #endregion
    }
}
