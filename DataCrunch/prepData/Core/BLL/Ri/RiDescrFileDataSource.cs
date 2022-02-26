using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RiDescrFileDataSource : DataProvider<RiDescrFile>
    {
        public RiDescrFileDataSource(string filePath) : base(filePath)
        {
        }

        protected override List<RiDescrFile> GetAllLines(StreamReader reader, int posStart, int posEnd)
        {
            List<RiDescrFile> l_lines;
            using (var csv = new CsvReader(reader, CultureInfo.InstalledUICulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.RegisterClassMap<RiDescrFileClassMap>();
                l_lines = csv.GetRecords<RiDescrFile>().ToList();
            }
            return l_lines;

        }
    }
}
