using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LogItem : ViewModelBase
    {
        private String _message;
        public String Message
        {
            get { return _message; }
            set
            {
                _message = value;
                this.RaisePropertyChanged();
            }
        }

        public LogItem(String message)
        {
            Message = message;
        }
    }
}
