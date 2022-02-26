using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ILines
    {
        //bool Parse(StreamReader reader);
        bool Parse(string line, int posStart = 0, int posEnd = 0);
    }
}
