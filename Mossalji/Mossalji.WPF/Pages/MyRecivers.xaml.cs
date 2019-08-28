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
        private List<Reciever> AllRecords { set; get; }
        private List<Reciever> filtered = new List<Reciever>(); public MyRecivers()
        {
            InitializeComponent();

            FilterSide.FilterButton.Click += ShowFIlterButton_Click;
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void DataGridBinding()
        {
            DV.ItemsSource = filtered;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var Reciver = DV.SelectedItem as Reciever;
            if (Reciver == null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddReciver(Reciver, false));

            ((UserControl)AdditionalControl.Content).IsEnabledChanged += AddingControlDisabled;
        }
        private void AddingControlDisabled(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (DataService DS = new DataService())
            {
                AllRecords = DS.Receivers.Where(r => r.Disabled != true).
                          ToList();

                ReciverCity.ItemsSource = DS.Receivers.Select(r => r.City).Distinct().ToList();
                ReciverRegion.ItemsSource = DS.Receivers.Select(r => r.Place).Distinct().ToList();
            }
            // Initiaing the filtered list
            filtered = AllRecords;
            DataGridBinding();
        }


    
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var reciver= DV.SelectedItem as Reciever;
            if (reciver== null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddReciver(reciver, true));

        }


        private void ShowFIlterButton_Click(object sender, RoutedEventArgs e)
        {
            Filter.Visibility = Visibility.Visible;
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            filtered = AllRecords.Where(o =>
            (ReciverCity.SelectedItem == null || o.City == ReciverCity.SelectedValue.ToString()) &&
            (ReciverRegion.SelectedItem == null || o.Place == ReciverRegion.SelectedValue.ToString())
            )
            .ToList();

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
            (ReciverCity.SelectedItem == null || o.City == ReciverCity.SelectedValue.ToString()) &&
            (ReciverRegion.SelectedItem == null || o.Place == ReciverRegion.SelectedValue.ToString())&&
            (o.CustomerName.Contains(SearchBox.Text))
            )
            .ToList();

            }
            else
            {
                filtered = AllRecords.Where(o =>

              (o.CustomerName.Contains(SearchBox.Text))
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

        private void ClearPlace_Click(object sender, RoutedEventArgs e)
        {
            ReciverRegion.SelectedIndex = -1;
        }

        private void ClearCity_Click(object sender, RoutedEventArgs e)
        {
            ReciverCity.SelectedIndex = -1;
        }

     
    }
}
