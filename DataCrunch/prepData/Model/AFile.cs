using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class AFile
    {
        protected String _fileName;

        protected String _OutputFileName;

        protected String _OutputPathName;

        #region constructor
        public AFile()
        {
            _fileName = "";
            this._OutputFileName = "";
            this._OutputPathName = "";
        }

        public AFile(String fileName)
        {
            this._fileName = fileName;
            this._OutputFileName = "";
            this._OutputPathName = "";
        }
        #endregion

        #region abstract members
      
        public abstract void ReadFile();

        public abstract void ExportFile();

        public BackgroundWorker worker { protected get; set; }
        #endregion
    }
}
