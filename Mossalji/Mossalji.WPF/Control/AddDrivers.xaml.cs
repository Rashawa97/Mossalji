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
    /// Interaction logic for AddDrivers.xaml
    /// </summary>
    public partial class AddDrivers : UserControl
    {
        private Driver _driver;

        public AddDrivers()
        {
            InitializeComponent();

            this.Focus();
        }

        public AddDrivers(Driver driver, bool detail)
        {
            InitializeComponent();

            this.Focus();

            _driver = driver;

            FillControl();

            if (detail)
                LockEditing();
        }

        private void LockEditing()
        {
            this.CarStatus.IsEnabled = false;
            this.DriverStatus.IsEnabled = false;
            this.DriverName.IsEnabled = false;
            this.CarNumber.IsEnabled = false;
            this.save.Visibility=Visibility.Collapsed;
        }

        private void FillControl()
        {
            this.CarNumber.Text = _driver.CarNumber;
            this.DriverName.Text = _driver.DriverName;
            this.CarStatus.SelectedIndex = (int)_driver.CarStatus;
            this.DriverStatus.SelectedIndex = (int)_driver.DriverStatus;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Validate())
            {
                if(_driver==null)
                {
                    Driver driver = new Driver()
                    {
                        CarNumber = CarNumber.Text,
                        CarStatus = (CarStatus)CarStatus.SelectedIndex,
                        DriverStatus = (DriverStatus)DriverStatus.SelectedIndex,
                        DriverName = DriverName.Text
                    };

                    using (DataService DS = new DataService())
                    {
                        DS.Drivers.Add(driver);
                        DS.SaveChanges();
                    }
                }
                else
                {
                    using (DataService DS = new DataService())
                    {
                        var driver = DS.Drivers.FirstOrDefault(d => d.Id == _driver.Id);
                        driver.CarNumber = CarNumber.Text;
                        driver.CarStatus = (CarStatus)CarStatus.SelectedIndex;
                        driver.DriverStatus = (DriverStatus)DriverStatus.SelectedIndex;
                        driver.DriverName = DriverName.Text;

                        DS.SaveChanges();
                    }
                }

                MessageBox.Show("تم حفظ السائق", "تم بنجاح", MessageBoxButton.OK, MessageBoxImage.Information);

                this.IsEnabled = false;

                ((ContentControl)this.Parent).Content = null;

            }
            
        }

        private bool Validate()
        {
            if (
                string.IsNullOrEmpty(DriverName.Text)||
                string.IsNullOrEmpty(CarNumber.Text)||
                DriverStatus.SelectedIndex<0||
                CarStatus.SelectedIndex<0
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
