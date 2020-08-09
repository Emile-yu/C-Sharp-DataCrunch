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

        protected BackgroundWorker _Worker; 
        #region constructor
        public AFile(BackgroundWorker Worker)
        {
            _fileName = "";
            this._OutputFileName = "";
            this._OutputPathName = "";
            _Worker = Worker;
        }

        public AFile(String fileName, BackgroundWorker Worker)
        {
            this._fileName = fileName;
            this._OutputFileName = "";
            this._OutputPathName = "";
            _Worker = Worker;
        }
        #endregion

        #region abstract members
      
        public abstract void ReadFile();

        public abstract void ExportFile();

        #endregion
    }
}
