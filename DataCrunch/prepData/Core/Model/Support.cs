using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /*public class SupportParser : ILineParser
    {
        public List<Support> Parse(StreamReader reader)
        {
            List<Support> l_supp;
            using (var csv = new CsvReader(reader, CultureInfo.InstalledUICulture))
            {
                l_supp = csv.GetRecords<Support>().ToList();
            }
            return l_supp;
        }

    }*/

    public class Support : ILines, ISerializable
    {
        public int MedNum { get; set; }

        public int IdTitre { get; set; }

        public int Parution { get; set; }

        public int Jour { get; set; }

        public bool Parse(string line, int posStart = 0, int posEnd = 0)
        {
            return true;
        }

        public string Serialize()
        {
            return $"{MedNum};{IdTitre};{Parution};{Jour}";
        }
    }

    public class SupportMapClass : ClassMap<Support>
    {
        public SupportMapClass()
        {
            Map(m => m.MedNum).Name("med_num0");
            Map(m => m.IdTitre).Name("ID_ONE_titre");
            Map(m => m.Parution).Name("ID_parution");
            Map(m => m.Jour).Name("Rang_jour");
        }
    }

    public class SupportExport
    {
        public int MedNum { get; set; }

        public int Parution { get; set; }

        public int Jour { get; set; }

        public SupportExport(int medNum, int parution, int jour)
        {
            this.MedNum = medNum;
            this.Parution = parution;
            this.Jour = jour;
        }
    }
}
