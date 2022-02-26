using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   
    public class Ri : ILines
    {
        public string SupportId { get; set; }

        public string IndividuId { get; set; }

        public Double RiValue { get; set; }

        public bool Parse(string line, int posStart = 0, int posEnd = 0)
        {
            return true;
        }
    }

    public class RiDescrFile : ILines
    {
        public int PosBegin { get; set; }

        public int PosEnd { get; set; }

        public string Type { get; set; }

        public string SupportCode { get; set; }

        public string Nb { get; set; }

        public bool Parse(string line, int posStart = 0, int posEnd = 0)
        {
            return true;
        }
    }

    public class RiDescrFileClassMap : ClassMap<RiDescrFile>
    {
        public RiDescrFileClassMap()
        {
            Map(m => m.PosBegin).Name("POS1");
            Map(m => m.PosEnd).Name("POS2");
            Map(m => m.Type).ConvertUsing(row => row.GetField<string>(3) == "ID" ?
            "Support" : "Individual"
            );
            Map(m => m.SupportCode).Name("CODE");//.ToString().Substring(1);
            Map(m => m.Nb).Name("NB #0");
        }
    }
}
