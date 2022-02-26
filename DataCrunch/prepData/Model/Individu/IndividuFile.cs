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
    public class IndividuFile : AFile, IContent
    {
        #region private
        //private IndividuDataSource _individuDataSource;
        #endregion

        #region membre private
        public int StartPos { get; private set; }

        public int EndPos { get; private set; }
   
        public List<string> Individus { get; private set; }

        //public List<Individu> Individus { get; private set; }
        #endregion

        #region constructor
        public IndividuFile(String fileName, BackgroundWorker Worker, int Start, int End) : base(fileName, Worker)
        {
            StartPos = Start;
            EndPos = End;

            ReadFile();
        }
        #endregion

        #region operations
        public int GetContentSize()
        {
            return Individus.Count();
        }

        public override void ReadFile()
        {
            if (String.IsNullOrEmpty(this._fileName))
            {
                throw new Exception("File Name is vide");
            }

            if (this.EndPos < 0 || this.StartPos < 0)
            {
                throw new Exception("The position can not be negative !");
            }

            if (this.EndPos < this.StartPos)
            {
                throw new Exception("The starting position is wrong !");
            }

            _Worker.ReportProgress(1, new DataLogs(LogType.None, "traitement en cours..."));

            //_individuDataSource = new IndividuDataSource(this._fileName, StartPos, EndPos);
            //Individus = _individuDataSource.Provider();

            Individus = File.ReadAllLines(this._fileName, Encoding.GetEncoding("iso-8859-15")).Select(l => l.Substring(this.StartPos, this.EndPos - this.StartPos)).ToList();

           
        }
        public override void ExportFile()
        {
            if (String.IsNullOrEmpty(this._fileName))
            {
                throw new Exception("File Name is vide"); ;
            }

            this._OutputPathName = FilePathManager.getInstance().getPathName(DataType.Individu, this._fileName);
            
            if (!Directory.Exists(this._OutputPathName))
            {
                Directory.CreateDirectory(this._OutputPathName);
            }
            //this._OutputFileName = @"C:\yu\project\Navigation_UserControl\Navigation_UserControl\bin\Debug\individu\Individu";
            this._OutputFileName = _OutputPathName + "\\Individus";
            using (var writer = new StreamWriter(_OutputFileName + ".csv"))
            {
                foreach (String data in Individus)
                //foreach (Individu ind in Individus)
                {
                    _Worker.ReportProgress(1, new DataLogs(LogType.None, String.Format("{0} a été ajouté ...", data)));
                    writer.WriteLine(data);
                    //_Worker.ReportProgress(1, new DataLogs(LogType.None, String.Format("{0} a été ajouté ...", ind.Serialize())));
                    //writer.WriteLine(ind.Serialize());
                }
            }

                /*int count = 0;
                for (int i = 0; i < _Individus.Count(); ++i)
                {
                    File.WriteAllText(this._OutputFileName + ".csv", _Individus[i]);
                    reportProgress(count++);
                }*/
                //File.WriteAllLines(outPath, l_line.ToArray());


                /*string[] l_line = File.ReadAllLines(this.FilePath);
                List<string> res = new List<string>();
                foreach(string l in l_line)
                {
                    res.Add(l.Substring(Int32.Parse(this.Begin),Int32.Parse(this.End)).Trim());
                }
                string outPath = @"C:\yu\project\ExportId\ExportId\bin\Debug\indidivu\" + "individu.csv";

                File.WriteAllLines(outPath, res.ToArray());*/
            }
        #endregion
    }
}
