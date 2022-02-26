using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class IndividuDataSource : DataProvider<Individu>
    {
        public IndividuDataSource(string filePath, int posStart, int posEnd) : base(filePath, posStart, posEnd)
        {
        }

        /*protected override List<Individu> GetAllLines(StreamReader reader, int posStart, int posEnd)
        {
            List<Individu> l_lines = new List<Individu>();
            string l_line;
            int l_error = 0;
            while ((l_line = reader.ReadLine()) != null)
            {
                Individu ind = new Individu();
                if (ind.Parse(l_line, posStart, posEnd)) l_lines.Add(ind);
                else l_error++;
            }
            if (l_error > 0)
                Console.WriteLine($"Avertissement : {l_error} lignes n'ont pas pu être récupérées.");

            return l_lines;
        }*/
    }
}
