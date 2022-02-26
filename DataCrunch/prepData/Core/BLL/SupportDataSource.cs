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
    public class SupportDataSource : DataProvider<Support>
    {
        public SupportDataSource(string filePath) : base(filePath)
        {
        }

        protected override List<Support> GetAllLines(StreamReader reader, int posStart, int posEnd)
        {
            List<Support> l_lines;

            using (var csv = new CsvReader(reader, CultureInfo.InstalledUICulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.RegisterClassMap<SupportMapClass>();
                l_lines = csv.GetRecords<Support>().ToList();
            }
            return l_lines;          
        }

        public void Writer(string pathOutPut, List<Support> supps)
        {
            List<SupportExport> res = supps.Select(o => new SupportExport(o.MedNum, o.Parution, o.Jour)).ToList();
            using (var writer = new StreamWriter(pathOutPut))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InstalledUICulture))
                {
                    csvWriter.Configuration.HasHeaderRecord = false;
                    csvWriter.WriteRecords(res);

                }
            }
        }
    }
}
