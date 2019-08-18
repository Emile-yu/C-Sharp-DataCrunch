using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C_Sharp
{
    class Stream_Reader_Writer
    {
        string file_in, file_out;
        public Stream_Reader_Writer(string path_in, string path_out) {
            file_in = path_in;
            file_out = path_out;
        }
        public void ReadWriteFile() {
            using (StreamReader sr = new StreamReader(file_in)) {
                                                                  
               using (StreamWriter sw = new StreamWriter(file_out,append:true)) {//追加到结尾
                    string str;
                    while ((str = sr.ReadLine()) != null) {
                        sw.WriteLine(str);
                    }
                
                }
            }
            Console.WriteLine("OK");
        }
    }
}
