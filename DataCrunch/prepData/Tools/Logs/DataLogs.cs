using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class DataLogs
    {
        public String Message { get; private set; }

        public DataLogs(String message)
        {
            Message = message;
        }
    }
}
