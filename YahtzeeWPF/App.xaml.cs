using System.Windows;

namespace YahtzeeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel();

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
    }
}