using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DocumentViewProviderFactory
    {
        #region static
        private static DocumentViewProviderFactory _instance = null;
        public static DocumentViewProviderFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DocumentViewProviderFactory();
                }
                return _instance;
            }
        }
        #endregion

        #region public properties

        public Dictionary<DocumentViewType, IDocumentViewProvider> Providers { get; private set; }

        #endregion

        #region constructor
        private DocumentViewProviderFactory()
        {
            Providers = new Dictionary<DocumentViewType, IDocumentViewProvider>();
        }
        #endregion

       
    }
}
