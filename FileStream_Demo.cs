using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C_Sharp
{
    class FileStream_Demo
    {
        string file_in,file_out;
        public FileStream_Demo(string path_in, string path_out) {
            file_in = path_in;
            file_out = path_out;
        }
        public void ReadWriteFile() {
            using (FileStream f_in = new FileStream(file_in, FileMode.Open, FileAccess.Read)) {
                using (FileStream f_out = new FileStream(file_out, FileMode.OpenOrCreate, FileAccess.Write)) {
                    byte[] buffer = new byte[1024];
                    int bytecount = f_in.Read(buffer, 0, 1024);
                    while (bytecount > 0) {
                        f_out.Write(buffer, 0, bytecount);
                        bytecount = f_in.Read(buffer, 0, 1024);

                    }
                }
            }
            Console.WriteLine("OK"); 
        }
    }
}
