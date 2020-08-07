using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public enum DataType
    {
        Support,
        Ri,
        Individu,
        None
    };

    public class FilePathManager
    {
        #region membres

       

        private static String[] data = { " Support", " Ri", " Individu" };

        private String yearCurrent = DateTime.Now.Year.ToString();

        private String ONENEXT_PathName = @"\ONE NEXT ";
        private String ONENEXRPRIMIUM__PathName = @"\ONE NEXT PREMIUM ";
        private String ONENEXT_FileName = @"\ONE NEXT 2020_support_";
        private String ONENEXRPRIMIUM__FileName = @"\ONE NEXT PREMIUM 2020_support_";

        #endregion

        #region singleton
        private static FilePathManager _instance = null;

        public static FilePathManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new FilePathManager();
            }
            return _instance;
        }
        #endregion

        #region constructor

        private FilePathManager()
        {
            ONENEXT_PathName += yearCurrent;
            ONENEXRPRIMIUM__PathName += yearCurrent;
            ONENEXT_FileName = @"\ONE NEXT " + yearCurrent + "_support_";
            ONENEXRPRIMIUM__FileName = @"\ONE NEXT PREMIUM " + yearCurrent + "_support_";
        }
        #endregion

        #region operations
        private static String getData(DataType type)
        {
            return data[(int)type];
        }

        public String getPathName(DataType type, String InputFileName)
        {
            if (String.IsNullOrEmpty(InputFileName))
            {
                throw new Exception("File Name is vide");
            }

            if (type == DataType.None)
            {
                throw new Exception("data type is null");
            }

            /*if (type == dataType.Individu)
            {
                return "";
            }*/
            String pathParent = Directory.GetParent(InputFileName).FullName;

            if (InputFileName.ToUpper().Contains("PREMIUM"))
            {
                return pathParent + ONENEXRPRIMIUM__PathName + getData(type);
            }
            return pathParent + ONENEXT_PathName + getData(type);



        }

        public String getFileName(DataType type, String InputFileName)
        {
            if (String.IsNullOrEmpty(InputFileName))
            {
                return "";
            }
            if (InputFileName.ToUpper().Contains("PREMIUM"))
            {
                return getPathName(type, InputFileName) + ONENEXRPRIMIUM__FileName;
            }
            return getPathName(type, InputFileName) + ONENEXT_FileName;
        }
        #endregion


    }
}
