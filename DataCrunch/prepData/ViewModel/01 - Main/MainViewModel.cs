using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Tools;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _gotoSupport;
        public ICommand GoToSupport
        {
            get { return this._gotoSupport; }
            set
            {
                this._gotoSupport = value;
                this.RaisePropertyChanged("Support Page");
            }
        }

        private ICommand _gotoIndividu;
        public ICommand GoToIndividu
        {
            get { return this._gotoIndividu; }
            set
            {
                this._gotoIndividu = value;
                this.RaisePropertyChanged("Individu Page");
            }
        }

        private ICommand _gotoRi;
        public ICommand GoToRi
        {
            get { return this._gotoRi; }
            set
            {
                this._gotoRi = value;
                this.RaisePropertyChanged("Ri Page");
            }
        }

        private UserControl _activeView;
        public UserControl ActiveView
        {
            get { return this._activeView; }
            set
            {
                this._activeView = value;
                this.RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            GoToSupport = new ActionCommand(GotoSupportCommand);

            GoToIndividu = new ActionCommand(GotoIndividuCommand);

            GoToRi = new ActionCommand(GotoRiCommand);
        }

        private void GotoSupportCommand(object parmater)
        {
            //Navigation.Navigate(Navigation.PageSupport, Page1ViewModel);

            // provides the active view
            IDocumentViewProvider l_viewProvider = null;
            if (DocumentViewProviderFactory.Instance.Providers.TryGetValue(DocumentViewType.SupportPage, out l_viewProvider))
                this.ActiveView = l_viewProvider.View;
        }

        private void GotoIndividuCommand(object parmater)
        {
            //Navigation.Navigate(Navigation.PageIndividu, Page2ViewModel);

            // provides the active view
            IDocumentViewProvider l_viewProvider = null;
            if (DocumentViewProviderFactory.Instance.Providers.TryGetValue(DocumentViewType.IndividuPage, out l_viewProvider))
                this.ActiveView = l_viewProvider.View;
        }

        private void GotoRiCommand(object parmater)
        {
            //Navigation.Navigate(Navigation.PageRi, Page3ViewModel);

            // provides the active view
            IDocumentViewProvider l_viewProvider = null;
            if (DocumentViewProviderFactory.Instance.Providers.TryGetValue(DocumentViewType.RiPage, out l_viewProvider))
                this.ActiveView = l_viewProvider.View;
        }

    }
}
