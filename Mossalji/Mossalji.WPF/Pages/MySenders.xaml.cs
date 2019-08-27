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
    /// Interaction logic for MySenders.xaml
    /// </summary>
    public partial class MySenders : UserControl
    {
        private List<Sender> AllRecords { set; get; }
        private List<Sender> filtered = new List<Sender>();
        public MySenders()
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
                AllRecords = DS.Senders.Where(r => r.Disabled != true).
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

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var sendeer = DV.SelectedItem as Sender;
            if (sendeer == null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddSender(sendeer, true));

        }
        private void AddingControlDisabled(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadData();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var sendeer = DV.SelectedItem as Sender;
            if (sendeer== null)
                return;

            AdditionalControl.Content = new OverlayControl( new AddSender(sendeer, false));

            ((UserControl)AdditionalControl.Content).IsEnabledChanged += AddingControlDisabled;

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            filtered = AllRecords.Where(o =>
           (Activity.SelectedItem == null || o.Activity == (Data.Enums.Activity)Activity.SelectedIndex) &&
           (FinanicalStatus.SelectedItem == null || o.FinancialStatus == (Data.Enums.FinancialStatus)FinanicalStatus.SelectedIndex)
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
            (Activity.SelectedItem == null || o.Activity == (Data.Enums.Activity)Activity.SelectedIndex) &&
            (FinanicalStatus.SelectedItem == null || o.FinancialStatus == (Data.Enums.FinancialStatus)FinanicalStatus.SelectedIndex) &&
            (o.ClientName.Contains(SearchBox.Text))
            )
            .ToList();

            }
            else
            {
                filtered = AllRecords.Where(o =>

              (o.ClientName.Contains(SearchBox.Text))
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

        private void ClearActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity.SelectedIndex = -1;
        }

        private void ClearFiniacialStatus_Click(object sender, RoutedEventArgs e)
        {
           FinanicalStatus.SelectedIndex = -1;
        }
    }
}
