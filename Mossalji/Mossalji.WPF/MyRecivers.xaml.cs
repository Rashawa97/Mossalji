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
    /// Interaction logic for MyRecivers.xaml
    /// </summary>
    public partial class MyRecivers : UserControl
    {
        private List<Reciver> AllRecords { set; get; }
        private List<Reciver> filtered = new List<Reciver>(); public MyRecivers()
        {
            InitializeComponent();
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {
            using (DataService DS = new DataService())
            {
                AllRecords = DS.Receivers.Where(r => r.Disabled != true).
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
