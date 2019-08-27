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
using Mossalji.Data.DataModels;

namespace Mossalji.WPF
{
    /// <summary>
    /// Interaction logic for MyOrders.xaml
    /// </summary>
    public partial class MyOrders : UserControl
    {

        private List<Order> AllRecords { set; get; }
        private List<Order> filtered = new List<Order>();
        public MyOrders()
        {
            InitializeComponent();

            FilterSide.FilterButton.Click += ShowFIlterButton_Click;
        }


        void OnLoad(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (DataService DS = new DataService())
            {
                AllRecords = DS.Orders.
                    Include(nameof(Order.Driver)).
                    Include(nameof(Order.Client)).
                    Include(nameof(Order.Customer)).
                    Where(r => r.Disabled != true).
                    ToList();

                OrderType.ItemsSource = DS.Orders.Select(o => o.OrderType).Distinct().ToList();
            }


            // Initiaing the filtered list
            filtered = AllRecords;
            DataGridBinding();
        }

        private void DataGridBinding()
        {
            DV.ItemsSource = filtered;
       
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var order= DV.SelectedItem as Order;
            if (order == null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddOrder(order, false));

            ((UserControl)AdditionalControl.Content).IsEnabledChanged += AddingControlDisabled;

        }
        private void AddingControlDisabled(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadData();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var order= DV.SelectedItem as Order;
            if (order == null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddOrder(order, true));

        }



        private void ShowFIlterButton_Click(object sender, RoutedEventArgs e)
        {
            Filter.Visibility = Visibility.Visible;
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            filtered = AllRecords.Where(o =>
            (OrderType.SelectedItem==null|| o.OrderType == OrderType.SelectedValue.ToString())&&
            (OrderStatus.SelectedItem==null|| o.OrderStatus == (Data.Enums.OrderStatus)OrderStatus.SelectedIndex)
            )
            .ToList() ;

            DataGridBinding();
        }

        private void CancelFilterButton_Click(object sender, RoutedEventArgs e)
        {
            filtered = AllRecords;

            DataGridBinding();

            Filter.Visibility = Visibility.Collapsed;

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (Filter.Visibility == Visibility.Visible)
            {
                filtered = AllRecords.Where(o =>
            (OrderType.SelectedItem == null || o.OrderType == OrderType.SelectedValue.ToString()) &&
            (OrderStatus.SelectedItem == null || o.OrderStatus == (Data.Enums.OrderStatus)OrderStatus.SelectedIndex) &&
            (o.OrderDescription.Contains(SearchBox.Text))
            )
            .ToList();

            }
            else
            {
                filtered = AllRecords.Where(o =>
              
              (o.OrderDescription.Contains(SearchBox.Text))
              )
              .ToList();

            }
            DataGridBinding();

        }

        private void ClearSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            SearchButton_Click(sender, e);
        }

        private void ClearOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            OrderStatus.SelectedIndex = -1;
        }

        private void ClearOrderType_Click(object sender, RoutedEventArgs e)
        {
            OrderType.SelectedIndex = -1;
        }
    }
}

