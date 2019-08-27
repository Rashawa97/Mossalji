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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : UserControl
    {

        private Order _order;

        public AddOrder()
        {
            InitializeComponent();
            Load();
        }


        public AddOrder(Order order, bool detail)
        {
            InitializeComponent();

            Load();

            _order = order;

            FillControl();

            if (detail)
                LockEditing();
        }


        private void Load()
        {
            this.Focus();

            using (DataService DS = new DataService())
            {
                var drivers = DS.Drivers.Where(d => d.Disabled != true).ToList();

                Drivers.ItemsSource = drivers;

                var senders = DS.Senders.Where(s => s.Disabled != true).ToList();

                Senders.ItemsSource = senders;
                var recivers= DS.Receivers.Where(r => r.Disabled != true).ToList();

               Recivers.ItemsSource = recivers;
            }
        }


        private void LockEditing()
        {
            this.OrderType.IsEnabled = false;
            this.OrderDateTime.IsEnabled = false;
            this.OrderDescription.IsEnabled = false;
            this.Volume.IsEnabled = false;
            this.Wieght.IsEnabled = false;
            this.Value.IsEnabled = false;
            this.Tax.IsEnabled = false;
            this.MossaljiTaxPercentage.IsEnabled = false;
            this.MossaljiTaxDinnar.IsEnabled = false;
            this.DeliveryTax.IsEnabled = false;
            this.PaymentMethod.IsEnabled = false;
            this.OrderCreationTime.IsEnabled = false;
            this.PackageDeleveringTime.IsEnabled = false;
            this.PackageReceivingTime.IsEnabled = false;
            this.OrderStatus.IsEnabled = false;
            this.SaveOrder.Visibility = Visibility.Collapsed;

            this.Drivers.IsEnabled = false;
            this.Recivers.IsEnabled = false;
            this.Senders.IsEnabled = false;

            this.AddDriver.IsEnabled = false;
            this.AddReciver.IsEnabled = false;
            this.AddSender.IsEnabled = false;


        }

        private void FillControl()
        {
            this.OrderType.Text = _order.OrderType;
            this.OrderDescription.Text = _order.OrderType;
            this.Volume.Text = _order.Volume;
            this.Wieght.Text = _order.Wieght.ToString();
            this.Value.Text = _order.Value.ToString();
            this.Tax.Text = _order.Tax.ToString();
            this.MossaljiTaxPercentage.Text = _order.MossaljiTaxPercentage.ToString();
            this.MossaljiTaxDinnar.Text = _order.MossaljiTaxDinnar.ToString();
            this.DeliveryTax.Text = _order.DeliveryTax.ToString();
            this.PaymentMethod.SelectedIndex = (int)_order.PaymentMethod;
            this.OrderCreationTime.SelectedTime = _order.OrderCreationTime;
            this.PackageDeleveringTime.SelectedTime = _order.PackageDeleveringTime;
            this.PackageReceivingTime.SelectedTime = _order.PackageReceivingTime;
            this.OrderDateTime.SelectedTime = _order.OrderDateTime;
            this.OrderStatus.SelectedIndex = (int)_order.OrderStatus;

            this.Drivers.SelectedItem = _order.Driver==null ? null:((List<Driver>)this.Drivers.ItemsSource).FirstOrDefault(d => d.Id == _order.Driver.Id);
            this.Senders.SelectedItem = _order.Client == null ? null : ((List<Sender>)this.Senders.ItemsSource).FirstOrDefault(s => s.Id == _order.Client.Id); ;
            this.Recivers.SelectedItem = _order.Customer == null ? null : ((List<Reciver>)this.Recivers.ItemsSource).FirstOrDefault(d => d.Id == _order.Customer.Id);
            /////////////////////

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            ((ContentControl)this.Parent).Content = null;
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (_order == null)
                {
                    Order ord = new Order()
                    {
                        OrderStatus = (OrderStatus)OrderStatus.SelectedIndex,
                        OrderType = OrderType.Text,
                        OrderDescription = OrderDescription.Text,
                        Volume = Volume.Text,
                        Wieght = Convert.ToInt32(Wieght.Text),
                        Value = Convert.ToDouble(Value.Text),
                        Tax = Convert.ToDouble(Tax.Text),
                        MossaljiTaxDinnar = Convert.ToDouble(MossaljiTaxDinnar.Text),
                        MossaljiTaxPercentage = Convert.ToDouble(MossaljiTaxPercentage.Text),
                        PaymentMethod = (PaymentMethod)PaymentMethod.SelectedIndex,
                        DeliveryTax = Convert.ToDouble(DeliveryTax.Text),
                        OrderCreationTime = DateTime.Now,
                        DriverNotifyingTime = (DateTime)DriverNotifyingTime.SelectedTime,
                        PackageDeleveringTime = (DateTime)PackageDeleveringTime.SelectedTime,
                        PackageReceivingTime = (DateTime)PackageReceivingTime.SelectedTime,
                        OrderDateTime=(DateTime)OrderDateTime.SelectedTime


                    };

                    using (DataService DS = new DataService())
                    {
                        ord.Driver = DS.Drivers.First(d => d.Id == ((Driver)Drivers.SelectedItem).Id);

                        ord.Client = DS.Senders.First(d => d.Id == ((Sender)Senders.SelectedItem).Id);

                        ord.Customer = DS.Receivers.First(d => d.Id == ((Reciver)Recivers.SelectedItem).Id);

                        DS.Orders.Add(ord);
                        DS.SaveChanges();
                    }
                }
                else
                {
                    using (DataService DS = new DataService())
                    {
                        var order= DS.Orders.FirstOrDefault(o => o.Id == _order.Id);
                        order.OrderStatus = (OrderStatus)OrderStatus.SelectedIndex;
                        order.OrderType = OrderType.Text;
                        order.OrderDescription = OrderDescription.Text;
                        order.Volume = Volume.Text;
                        order.Wieght = Convert.ToInt32(Wieght.Text);
                        order.Value = Convert.ToDouble(Value.Text);
                        order.Tax = Convert.ToDouble(Tax.Text);
                        order.MossaljiTaxDinnar = Convert.ToDouble(MossaljiTaxDinnar.Text);
                        order.MossaljiTaxPercentage = Convert.ToDouble(MossaljiTaxPercentage.Text);
                        order.PaymentMethod = (PaymentMethod)PaymentMethod.SelectedIndex;
                        order.DeliveryTax = Convert.ToDouble(DeliveryTax.Text);
                        order.OrderCreationTime = DateTime.Now;
                        order.DriverNotifyingTime = (DateTime)DriverNotifyingTime.SelectedTime;
                        order.PackageDeleveringTime = (DateTime)PackageDeleveringTime.SelectedTime;
                        order.PackageReceivingTime = (DateTime)PackageReceivingTime.SelectedTime;
                        order.OrderDateTime = (DateTime)OrderDateTime.SelectedTime;

                        DS.SaveChanges();
                    }
                    
                }
                MessageBox.Show("تم حفظ الطلب", "تم بنجاح", MessageBoxButton.OK, MessageBoxImage.Information);

                this.IsEnabled = false;

                ((ContentControl)this.Parent).Content = null;
            }
        }

        private bool Validate()
        {
            if (
               string.IsNullOrEmpty(OrderType.Text) ||
               string.IsNullOrEmpty(OrderDescription.Text) ||
               string.IsNullOrEmpty(Volume.Text) ||
               string.IsNullOrEmpty(Wieght.Text) ||
               string.IsNullOrEmpty(Value.Text)


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


        private void AdditionalControlDisabled(object sender, DependencyPropertyChangedEventArgs e)
        {
            Load();
        }

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            AddItemControl.Content = new AddDrivers();

            ((ContentControl)AddItemControl.Content).IsEnabledChanged += AdditionalControlDisabled;
        }


        private void AddSender_Click(object sender, RoutedEventArgs e)
        {
            AddItemControl.Content = new AddSender();

            ((ContentControl)AddItemControl.Content).IsEnabledChanged += AdditionalControlDisabled;

        }

        private void AddReciver_Click(object sender, RoutedEventArgs e)
        {
            AddItemControl.Content = new AddReciver();

            ((ContentControl)AddItemControl.Content).IsEnabledChanged += AdditionalControlDisabled;

        }
    }
}