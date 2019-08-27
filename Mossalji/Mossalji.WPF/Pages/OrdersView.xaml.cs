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
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AdditionalControl.Content = new OverlayControl( new AddSender());
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AdditionalControl.Content = new OverlayControl( new AddOrder());
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AdditionalControl.Content = new OverlayControl( new AddReciver());
        }

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            AdditionalControl.Content = new OverlayControl( new AddDrivers());

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FilterSide.FilterButton.Visibility = Visibility.Collapsed;
        }
    }
}
