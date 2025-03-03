using System.Configuration;
using System.Data;
using System.Windows;

namespace IndividualWork3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new MainWindow().Show();
        }
    }

}
