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
using Mossalji.WPF.Models;

namespace Mossalji.WPF
{
    /// <summary>
    /// Interaction logic for MyOrders.xaml
    /// </summary>
    public partial class ComessionsReport : UserControl
    {

        private List<Order> AllRecords { set; get; }
        private List<Order> filtered = new List<Order>();
        public ComessionsReport()
        {
            InitializeComponent();

            //FilterSide.FilterButton.Click += ShowFIlterButton_Click;
        }


        void OnLoad(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public List<ComessionModel> ComessionModels;


        private void LoadData()
        {
            FilterSide.FilterButton.Visibility = Visibility.Collapsed;

            ComessionModels = new List<ComessionModel>();

            using (DataService DS = new DataService())
            {
                AllRecords = DS.Orders.
                    Include(nameof(Order.Driver)).
                    Include(nameof(Order.Sender)).
                    Include(nameof(Order.Reciever)).
                    Include(nameof(Order.Employee)).
                    Where(r => r.Disabled != true).
                    ToList();
                var a = new List<DateModel>();
                AllRecords.Select(o => new { o.OrderCreationTime.Month, o.OrderCreationTime.Year }).Distinct()
                    .OrderBy(d=>d.Year)
                    .ThenBy(d=>d.Month)
                    .ToList()
                    .ForEach(d=>
                    {
                        a.Add(new DateModel()
                        {
                            Month = d.Month,
                            Year = d.Year,
                        });
                    });

                Month.ItemsSource = a;
            }


            // Initiaing the filtered list
            filtered = AllRecords;
            DataGridBinding();
        }

        private void DataGridBinding()
        {
            ComessionModels = new List<ComessionModel>();
            filtered.Select(o => o.Driver).
                Distinct().
                ToList().
                ForEach(d =>
                {
                    ComessionModels.Add(new ComessionModel()
                    {
                        Driver = d,
                    });
                });

            foreach (ComessionModel comessionModel in ComessionModels)
            {
                comessionModel.DriverComession = filtered.
                    Where(o => o.Disabled != true && o.Driver.Id == comessionModel.Driver.Id).
                    Sum(o => o.DeliveryTax);

                comessionModel.MossaljiComession = filtered.
                    Where(o => o.Disabled != true && o.Driver.Id == comessionModel.Driver.Id).
                    Sum(o => o.MossaljiTaxDinnar);
                
            }


            Drivers.ItemsSource = ComessionModels;
            //DV.ItemsSource = filtered;
       
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //var order= DV.SelectedItem as Order;
            //if (order == null)
            //    return;

            //AdditionalControl.Content = new OverlayControl( new AddOrder(order, false));

            //((UserControl)AdditionalControl.Content).IsEnabledChanged += AddingControlDisabled;

        }
        private void AddingControlDisabled(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadData();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            //var order= DV.SelectedItem as Order;
            //if (order == null)
            //    return;

            //AdditionalControl.Content = new OverlayControl( new AddOrder(order, true));

        }



        private void ShowFIlterButton_Click(object sender, RoutedEventArgs e)
        {
            //Filter.Visibility = Visibility.Visible;
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            //filtered = AllRecords.Where(o =>
            //(OrderType.SelectedItem==null|| o.OrderType == OrderType.SelectedValue.ToString())&&
            //(OrderStatus.SelectedItem==null|| o.OrderStatus == (Data.Enums.OrderStatus)OrderStatus.SelectedIndex)
            //)
            //.ToList() ;

            //DataGridBinding();
        }

        private void CancelFilterButton_Click(object sender, RoutedEventArgs e)
        {
            //filtered = AllRecords;

            //DataGridBinding();

            //Filter.Visibility = Visibility.Collapsed;

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(Month.SelectedIndex<0)
            {
                filtered = AllRecords;
            }
            else
            {
                filtered = AllRecords.Where(o => o.OrderCreationTime.Month == ((DateModel)Month.SelectedItem).Month &&
                    o.OrderCreationTime.Year == ((DateModel)Month.SelectedItem).Year).ToList();
            }
            
            DataGridBinding();

        }

        private void ClearSearch_Click(object sender, RoutedEventArgs e)
        {
            //SearchBox.Text = "";
        }

        private void ClearOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            //OrderStatus.SelectedIndex = -1;
        }

        private void ClearOrderType_Click(object sender, RoutedEventArgs e)
        {
            //OrderType.SelectedIndex = -1;
        }

        private void ClearMonth_Click(object sender, RoutedEventArgs e)
        {
            Month.SelectedIndex = -1;
            SearchButton_Click(sender, e);

        }
    }
}

