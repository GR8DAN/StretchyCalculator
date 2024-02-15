using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace StretchyCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            //Exception catch all
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;

            //Subscribe to startup event...
            Startup += App_Startup;
        }
        //...to create our one off window
        void App_Startup(object sender, StartupEventArgs e)
        {
            StretchyCalculator.MainWindow.Instance.Show();
        }

        //Unhandle exceptions
        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unknown error: " + e.Exception.Message, "Calculation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

    }
}
