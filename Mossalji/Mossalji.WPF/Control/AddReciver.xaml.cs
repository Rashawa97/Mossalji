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
    /// Interaction logic for AddReciver.xaml
    /// </summary>
    public partial class AddReciver : UserControl
    {

        private Reciever _reciver;

        public AddReciver()
        {
            InitializeComponent();

            this.Focus();
        }

        public AddReciver(Reciever reciver, bool detail)
        {
            InitializeComponent();

            this.Focus();

            _reciver = reciver;

            FillControl();

            if (detail)
                LockEditing();
        }

        private void FillControl()
        {
            this.CustomerName.Text = _reciver.CustomerName;
            this.City.Text = _reciver.City;
            this.Place.Text= _reciver.Place;
            this.PhoneNumber.Text= _reciver.Place;
        }

        private void LockEditing()
        {
            this.CustomerName.IsEnabled = false;
            this.City.IsEnabled = false;
            this.Place.IsEnabled = false;
            this.PhoneNumber.IsEnabled = false;
 
            this.SaveCustomer.Visibility = Visibility.Collapsed;
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
                if (_reciver == null)
                {
                    Reciever reciver = new Reciever()
                    {
                      CustomerName = CustomerName.Text,
                        City = City.Text,
                      Place= Place.Text,
                       PhoneNumber = PhoneNumber.Text
                    };

                    using (DataService DS = new DataService())
                    {
                        DS.Receivers.Add(reciver);
                        DS.SaveChanges();
                    }
                }
                else
                {
                    using (DataService DS = new DataService())
                    {
                        var reciver = DS.Receivers.FirstOrDefault(r => r.Id == _reciver.Id);
                        reciver.CustomerName= CustomerName.Text;
                        reciver.City = City.Text;
                       reciver.Place = Place.Text;
                        reciver.PhoneNumber = PhoneNumber.Text;

                        DS.SaveChanges();
                    }
                }

                MessageBox.Show("تم حفظ الزبون", "تم بنجاح", MessageBoxButton.OK, MessageBoxImage.Information);

                this.IsEnabled = false;

                ((ContentControl)this.Parent).Content = null;

            }

        }
        private bool Validate()
        {
            if (
                string.IsNullOrEmpty(CustomerName.Text) ||
                string.IsNullOrEmpty(City.Text) ||
                string.IsNullOrEmpty(Place.Text) ||
                string.IsNullOrEmpty(PhoneNumber.Text) 
              
          
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
