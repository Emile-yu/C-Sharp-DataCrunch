using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using View;
using ViewModel;

namespace prepData
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            InitializeDocuments();

            this.StartupUri = new Uri("pack://application:,,,/View;component/01 - Main/MainView.xaml");


        }

        /// <summary>
        /// initializes the document views
        /// </summary>
        /// <returns></returns>
        private bool InitializeDocuments()
        {
            
            // adds the providers
            DocumentViewProviderFactory.Instance.Providers.Add(DocumentViewType.IndividuPage, new IndividuViewProvider());

            // adds the providers
            DocumentViewProviderFactory.Instance.Providers.Add(DocumentViewType.RiPage, new RiViewProvider());

            // adds the providers
            DocumentViewProviderFactory.Instance.Providers.Add(DocumentViewType.SupportPage, new SupportViewProvider());

            return true;
        }

    }

}
