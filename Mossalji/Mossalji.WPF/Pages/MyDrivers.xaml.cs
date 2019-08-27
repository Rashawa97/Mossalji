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
            FilterSide.FilterButton.Click += ShowFIlterButton_Click;

        }
        private void ShowFIlterButton_Click(object sender, RoutedEventArgs e)
        {
            Filter.Visibility = Visibility.Visible;
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var driver = DV.SelectedItem as Driver;
            if (driver == null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddDrivers(driver, false));

            ((UserControl)AdditionalControl.Content).IsEnabledChanged += AddingControlDisabled;
        }

        private void AddingControlDisabled(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadData();
        }
        

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var driver = DV.SelectedItem as Driver;
            if (driver == null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddDrivers(driver, true));
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            filtered = AllRecords.Where(o =>
          (DriverStatus.SelectedItem == null || o.DriverStatus == (Data.Enums.DriverStatus)DriverStatus.SelectedIndex) &&
          (CarStatus.SelectedItem == null || o.CarStatus== (Data.Enums.CarStatus)CarStatus.SelectedIndex)
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
          (DriverStatus.SelectedItem == null || o.DriverStatus == (Data.Enums.DriverStatus)DriverStatus.SelectedIndex) &&
          (CarStatus.SelectedItem == null || o.CarStatus == (Data.Enums.CarStatus)CarStatus.SelectedIndex) &&
            (o.DriverName.Contains(SearchBox.Text))
            )
            .ToList();

            }
            else
            {
                filtered = AllRecords.Where(o =>

              (o.DriverName.Contains(SearchBox.Text))
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

        private void ClearDriverStatus_Click(object sender, RoutedEventArgs e)
        {
            DriverStatus.SelectedIndex = -1;
        }

        private void ClearCarStatus_Click(object sender, RoutedEventArgs e)
        {
           CarStatus.SelectedIndex = -1;
        }
    }
}
