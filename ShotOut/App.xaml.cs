using ShotOut.ViewModels;
using ShotOut.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShotOut
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var v = new MainView();
            var vm = new MainViewModel();
            v.DataContext = vm;
            MainWindow = v;
            v.Show();
        }
    }
}
