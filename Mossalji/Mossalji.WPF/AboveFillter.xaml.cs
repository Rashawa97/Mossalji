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
    /// Interaction logic for AboveFillter.xaml
    /// </summary>
    public partial class AboveFillter : UserControl
    {
        public AboveFillter()
        {
            InitializeComponent();
        }

        private void DataNow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataNow.Text = DateTime.Now.ToString();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.EmploeeName.Text = ((MainWindow)App.Current.MainWindow).CurrentUser.EmployeeName;
        }
    }
}
