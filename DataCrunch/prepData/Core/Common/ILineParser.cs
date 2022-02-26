using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ILineParser
    {
        bool Parse(string line, int posStart = 0, int posEnd = 0);
    }
}
