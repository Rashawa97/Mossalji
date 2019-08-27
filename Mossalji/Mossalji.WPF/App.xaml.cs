using Mossalji.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Mossalji.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            InitiateDataBase();

            App.Current.MainWindow = new Login();
            //App.Current.MainWindow = new Test();

            App.Current.MainWindow.Show();

            base.OnStartup(e);
        }
        private static void InitiateDataBase()
        {
            using (DataService DS = new DataService())
            {
                if (!DS.Database.Exists())
                {
                    DS.Database.Initialize(true);
                }
            }

        }

    }
}
