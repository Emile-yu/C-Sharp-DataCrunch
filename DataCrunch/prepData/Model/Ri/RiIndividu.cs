using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RiIndividu
    {
        #region members

        private List<KeyValuePair<String, double>> _pRiIndividu = new List<KeyValuePair<String, double>>();

        #endregion

        #region conctructor

        public RiIndividu(String IndividuId, double Ri)
        {
            _pRiIndividu.Add(new KeyValuePair<string, double> (IndividuId, (double)(Ri / 1000000.0)));
        }

        #endregion

        #region operation

        public void Add(String IndividuId, double Ri)
        {
           
            _pRiIndividu.Add(new KeyValuePair<string, double>(IndividuId, (double)(Ri / 1000000.0)));
        }

        public List<KeyValuePair<String, double>> GetRiIndividu()
        {
            return _pRiIndividu;
        }
       
        #endregion

    }
}
