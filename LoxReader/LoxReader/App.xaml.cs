using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoxReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow;
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWindow = new LoxReader.MainWindow(e.Args);
            mainWindow.Show();
        }

    }
}
