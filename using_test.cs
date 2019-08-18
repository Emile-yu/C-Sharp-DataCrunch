using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Sharp
{
   
    class using_test : IDisposable
    {
        public void Dispose() {
            Console.WriteLine("Déconstructor");
        }
    }
}
