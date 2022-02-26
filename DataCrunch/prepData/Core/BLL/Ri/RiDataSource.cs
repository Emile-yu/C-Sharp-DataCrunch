using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RiDataSource
    {
        private string _filePath;
        private List<RiDescrFile> _riDescrFiles;

        public RiDataSource(string filePath, List<RiDescrFile> riDescrFiles) 
        {
            this._filePath = filePath;
            this._riDescrFiles = riDescrFiles;
        }

        public List<Ri> Provider()
        {
            List<Ri> l_lines;
            string l_filePath = _filePath;
            try
            {
                using (var reader = new StreamReader(l_filePath))
                {
                    l_lines = GetAllLines(reader);  
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l_lines;
        }

        private List<Ri> GetAllLines(StreamReader reader)
        {
            /*List<Ri> l_lines;
            string l_line;
            while ((l_line = reader.ReadLine()) != null)
            {
                Ri l_ri = new Ri();
                foreach (var item in _riDescrFiles)
                {

                }
            }
            return l_lines;*/
            return null;
        }
    }
}
