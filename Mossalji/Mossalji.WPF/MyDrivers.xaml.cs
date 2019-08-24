using Mossalji.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mossalji.WPF
{
    /// <summary>
    /// Interaction logic for My.xaml
    /// </summary>
    public partial class MyDrivers : UserControl
    {
        private List<Driver> AllRecords { set; get; }
        private List<Driver> filtered = new List<Driver>();
        public MyDrivers()
        {
            InitializeComponent();
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {
            using (DataService DS = new DataService())
            {
                AllRecords = DS.Drivers.Where(r => r.Disabled != true).
                          ToList();
            }
            // Initiaing the filtered list
            filtered = AllRecords;
            DataGridBinding();
        }

        private void DataGridBinding()
        {
            DV.ItemsSource = filtered;

        }
    }
}
