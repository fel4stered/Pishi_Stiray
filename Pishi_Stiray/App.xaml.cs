using DevExpress.Mvvm;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using Pishi_Stiray.ViewModels;
using Pishi_Stiray.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pishi_Stiray
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModelLocator.Init();
            base.OnStartup(e);
        }
    }
}
