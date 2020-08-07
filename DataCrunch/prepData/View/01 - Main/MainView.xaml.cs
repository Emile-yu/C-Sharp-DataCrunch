using MahApps.Metro.Controls;
using ViewModel;

namespace View
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();

        }
    }
}
