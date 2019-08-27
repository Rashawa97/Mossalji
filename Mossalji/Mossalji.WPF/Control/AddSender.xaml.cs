using Mossalji.Data.DataModels;
using Mossalji.Data.Enums;
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
    /// Interaction logic for AddSender.xaml
    /// </summary>
    public partial class AddSender : UserControl
    {
        private Sender _sender;

        public AddSender()
        {
            InitializeComponent();

            // TODO: Fix the problem of the rrectabgle being shown after the control is shown
            this.Focus();
        }
        public AddSender(Sender sender, bool detail)
        {
            InitializeComponent();

            this.Focus();

            _sender = sender;

            FillControl();

            if (detail)
                LockEditing();
        }

        private void LockEditing()
        {
            this.ClientName.IsEnabled = false;
            this.City.IsEnabled = false;
            this.Place.IsEnabled = false;
            this.Activity.IsEnabled = false;
            this.FinancialStatus.IsEnabled = false;
           
          this.SaveSender.Visibility = Visibility.Collapsed;
        }

        private void FillControl()
        {
            this.ClientName.Text = _sender.ClientName;
            this.City.Text = _sender.City;
            this.Place.Text = _sender.City;
            this.Activity.SelectedIndex = (int)_sender.Activity;
            this.FinancialStatus.SelectedIndex = (int)_sender.FinancialStatus;
        }

        private void SaveSender_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (_sender == null)
                {
                    Sender send = new Sender()
                    {
                        ClientName =ClientName.Text,
                        City = City.Text,
                        Place = Place.Text,
                       Activity = (Activity)Activity.SelectedIndex,
                       FinancialStatus=(FinancialStatus)FinancialStatus.SelectedIndex
                    };

                    using (DataService DS = new DataService())
                    {
                        DS.Senders.Add(send);
                        DS.SaveChanges();
                    }
                }
                else
                {
                    using (DataService DS = new DataService())
                    {
                        var send = DS.Senders.FirstOrDefault(s => s.Id == _sender.Id);
                        send.ClientName = ClientName.Text;
                        send.City = City.Text;
                        send.Place = Place.Text;
                        send.Activity = (Activity)Activity.SelectedIndex;
                        send.FinancialStatus = (FinancialStatus)FinancialStatus.SelectedIndex;

                        DS.SaveChanges();
                    }
                }

                MessageBox.Show("تم حفظ العميل", "تم بنجاح", MessageBoxButton.OK, MessageBoxImage.Information);

                this.IsEnabled = false;

                ((ContentControl)this.Parent).Content = null;

            }

        }

        private bool Validate()
        {
            if (
               string.IsNullOrEmpty(ClientName.Text) ||
               string.IsNullOrEmpty(City.Text) ||
               string.IsNullOrEmpty(Place.Text) ||
              FinancialStatus.SelectedIndex < 0 ||
              Activity.SelectedIndex < 0
               )
            {

                MessageBox.Show("تأكد من ادخال جميع الحقول", "خطا بالادخال ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else
            {
                return true;

            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            ((ContentControl)this.Parent).Content = null;

        }
    }
}
