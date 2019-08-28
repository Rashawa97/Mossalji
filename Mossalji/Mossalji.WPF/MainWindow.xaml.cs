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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public readonly Employee CurrentUser;

        public MainWindow(Employee employee)
        {
            CurrentUser = employee;

            InitializeComponent();

            MainContent.Content = new OrdersView();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainContent.Content = new MyOrders();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listview = sender as ListView;
            switch(listview.SelectedIndex)
            {
                case 0:
                    MainContent.Content = new OrdersView();
                    break;
                case 2:
                    MainContent.Content = new MyOrders();
                    break;
                case 3:
                    MainContent.Content = new MySenders();
                    break;
                case 4:
                    MainContent.Content = new MyRecivers();
                    break;
                case 5:
                    MainContent.Content = new MyDrivers();
                    break;
                case 7:
                    // Reports
                    MainContent.Content = new AccountsReport();
                    break;
                case 8:
                    // Reports
                    MainContent.Content = new ComessionsReport();
                    break;

            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWidnow = new Login();

            App.Current.MainWindow = loginWidnow;

            this.Hide();

            App.Current.MainWindow.Show();

            this.Close();
        }
    }
}
