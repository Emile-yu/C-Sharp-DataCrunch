using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewModel
{
    public enum DocumentViewType
    {
        None,
        IndividuPage,
        RiPage,
        SupportPage
    };

    public interface IDocumentViewProvider
    {
        UserControl View { get; }
    }
}
