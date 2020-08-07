using Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Support
{
    public class SupportFile : AFile, IContent
    {
        #region membres
        public Dictionary<string, string[]> Supports { get; private set; }
        #endregion

        #region constructor
        public SupportFile(String fileName) : base(fileName)
        {
            Supports = new Dictionary<string, string[]>();
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

            string[] l_lines = File.ReadAllLines(this._fileName).Where(o => !o.Contains("ID")).ToArray();

            Supports = l_lines.GroupBy(l => l.Split(';')[1]).ToDictionary(o => o.Key, o => o.ToArray());

        }

        public override void ExportFile()
        {

            if (String.IsNullOrEmpty(this._fileName))
            {
                throw new Exception("File Name is vide"); ;
            }

            this._OutputPathName = FilePathManager.getInstance().getPathName(FilePathManager.dataType.Support, this._fileName);
            this._OutputFileName = FilePathManager.getInstance().getFileName(FilePathManager.dataType.Support, this._fileName);
            if (!Directory.Exists(this._OutputPathName))
            {
                Directory.CreateDirectory(this._OutputPathName);
            }

            int count = 0;
           
            foreach (KeyValuePair<string, string[]> item in Supports)
            {
                File.WriteAllLines(this._OutputFileName + item.Key + ".csv", item.Value);
                worker.ReportProgress(count++,new DataLogs(String.Format("{0}.csv est généré ...", this._OutputFileName + item.Key)));
            }
       
        }
        
        #endregion
    }
}
