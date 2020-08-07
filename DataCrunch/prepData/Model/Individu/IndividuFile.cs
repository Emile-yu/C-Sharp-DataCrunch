using Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IndividuFile : AFile, IContent
    {
        #region membre private
        public int StartPos { get; private set; }
        public int EndPos { get; private set; }
   
        public List<string> Individus { get; private set; }
        #endregion

        #region constructor
        public IndividuFile(String fileName, int Start, int End) : base(fileName)
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

            Individus = File.ReadAllLines(this._fileName, Encoding.GetEncoding("iso-8859-15")).Select(l => l.Substring(this.StartPos, this.EndPos - this.StartPos)).ToList();

            //string outPath = @"C:\yu\project\Navigation_UserControl\Navigation_UserControl\bin\Debug\indidivu\" + "Individus.csv";
            //File.WriteAllLines(outPath, l_line.ToArray());
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
            int count = 0;
            using (var writer = new StreamWriter(_OutputFileName + ".csv"))
            { 
                foreach (String data in Individus)
                {
                    worker.ReportProgress(count++, new DataLogs(String.Format("{0} a été ajouté ...", data)));
                    writer.WriteLine(data);
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
