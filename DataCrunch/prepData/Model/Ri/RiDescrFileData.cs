using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RiDescrFileData
    {
        public enum DataType { None, Individual, Support };

        #region private membre

        public int BeginPos { get; private set; }

        public int EndPos { get; private set; }

        public int SupportCode { get; private set; }

        public DataType Type { get; private set; }
        #endregion

        #region conctructor
        public RiDescrFileData(int beginPos, int endPos, int supportCode, DataType type)
        {
            this.BeginPos = beginPos;
            this.EndPos = endPos;
            this.SupportCode = supportCode;
            this.Type = type;
        }
        #endregion

        #region operations
        public bool IsIndividual()
        {
            return Type == DataType.Individual;
        }

        public bool IsSupport()
        {
            return Type == DataType.Support;
        }
        #endregion
    }
}
