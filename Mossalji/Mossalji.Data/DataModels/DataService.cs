using Mossalji.Data.DataModels;
using Mossalji.Data.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.Data.DataModels
{
    public class DataService :DbContext

    {
        public DataService():base ("mossaljiDB")
        {
     
        }
        public virtual DbSet<Sender> Senders { get; set; }
        public virtual DbSet<Reciever> Receivers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (!Database.Exists())
                Database.SetInitializer(new DbInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public Employee Login(string userName, string password)
        {
            //TODO: Fix igonring case for the userName 
            var passHash = password.GetStringSha256Hash();
            var employee = this.Employees.FirstOrDefault(e => e.EmployeeName.Equals(userName,StringComparison.CurrentCulture) && e.PasswordHash == passHash);
            return employee;
        }


        
    }
    public class DbInitializer : CreateDatabaseIfNotExists<DataService>
    {
        /// <summary>
        /// Seeding the program types fixed for this Application
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DataService context)
        {

            // Seed the inserted information

            var employee = new Employee()
            {
                EmployeeName = "موصلجي",
                PasswordHash = "123emp".GetStringSha256Hash(),
            };

            context.Employees.Add(employee);

            #region Test Region

            #region Dummy Data

            // Drivers
            var driver1 = new Driver()
            {
                CarNumber = "1",
                CarStatus = Enums.CarStatus.ExternalCar,
                DriverStatus = Enums.DriverStatus.External,
                DriverName = "سمعان"
            };
            var driver2 = new Driver()
            {
                CarNumber = "2",
                CarStatus = Enums.CarStatus.InternalCar,
                DriverStatus = Enums.DriverStatus.External,
                DriverName = "حسنين"
            };
            var driver3 = new Driver()
            {
                CarNumber = "3",
                CarStatus = Enums.CarStatus.ExternalCar,
                DriverStatus = Enums.DriverStatus.Internal,
                DriverName = "حمدان"
            };
            var driver4 = new Driver()
            {
                CarNumber = "4",
                CarStatus = Enums.CarStatus.InternalCar,
                DriverStatus = Enums.DriverStatus.Internal,
                DriverName = "سائقنا المحترف"
            };

            // Senders
            var sender1 = new Sender()
            {
                Activity = Enums.Activity.Inc,
                City = "عمان",
                ClientName = "اسعد",
                Place = "طبربور"
            };
            var sender2 = new Sender()
            {
                Activity = Enums.Activity.OnlineInc,
                City = "عمان",
                ClientName = "شامل",
                Place = "طبربور"
            };
            var sender3 = new Sender()
            {
                Activity = Enums.Activity.Personal,
                City = "عمان",
                ClientName = "حسن",
                Place = "الجامعة"
            };
            var sender4 = new Sender()
            {
                Activity = Enums.Activity.Resturants,
                City = "عمان",
                ClientName = "Best Resturant",
                Place = "طبربور"
            };
            var sender5 = new Sender()
            {
                Activity = Enums.Activity.Shops,
                City = "مابدا",
                ClientName = "مكتبة",
                Place = "مادبا"
            };

            // Recievers
            var reciever1 = new Reciever()
            {
                City = "عمان",
                CustomerName = "سلام",
                PhoneNumber = "07777777777",
                Place = "طبربور"
            };
            var reciever2 = new Reciever()
            {
                City = "عمان",
                CustomerName = "فارس",
                PhoneNumber = "0778596554",
                Place = "طبربور"
            };
            var reciever3 = new Reciever()
            {
                City = "مادبا",
                CustomerName = "محمد",
                PhoneNumber = "079999999",
                Place = "مادبا"
            };
            var reciever4 = new Reciever()
            {
                City = "عمان",
                CustomerName = "حسني",
                PhoneNumber = "07785496312",
                Place = "الشميساني"
            };
            var reciever5 = new Reciever()
            {
                City = "عمان",
                CustomerName = "لؤي",
                PhoneNumber = "088965325",
                Place = "وسط البلد"
            };

            // Orders
            var order1 = new Order()
            {
                Sender = sender1,
                Driver = driver1,
                Reciever = reciever1,
                DeliveryTax = 15,
                Employee = employee,
                OrderDescription = "اكل",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "اكل",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.Paid,
                DriverNotifyingTime = DateTime.Now.AddDays(-1).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddDays(-1).AddHours(-3),
                OrderDateTime = DateTime.Now.AddDays(-1).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddDays(-1).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddDays(-1).AddHours(-6),

            };
            var order2 = new Order()
            {
                Sender = sender2,
                Driver = driver2,
                Reciever = reciever2,
                DeliveryTax = 13,
                Employee = employee,
                OrderDescription = "اكل",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "شركات",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.Paid,
                DriverNotifyingTime = DateTime.Now.AddDays(-1).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddDays(-1).AddHours(-3),
                OrderDateTime = DateTime.Now.AddDays(-1).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddDays(-1).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddDays(-1).AddHours(-6),

            };
            var order3 = new Order()
            {
                Sender = sender3,
                Driver = driver3,
                Reciever = reciever3,
                DeliveryTax = 15,
                Employee = employee,
                OrderDescription = "دفاتر",
                MossaljiTaxDinnar = 3,
                MossaljiTaxPercentage = 4,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "فردي",
                Tax = 14,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "5",
                Wieght = 5,
                Value = 7,
                FinancialStatus = Enums.FinancialStatus.Paid,
                DriverNotifyingTime = DateTime.Now.AddDays(-2).AddHours(-3),
                OrderCreationTime = DateTime.Now.AddDays(-2).AddHours(-1),
                OrderDateTime = DateTime.Now.AddDays(-1).AddHours(-3),
                PackageDeleveringTime = DateTime.Now.AddDays(-1).AddHours(-1),
                PackageReceivingTime = DateTime.Now.AddDays(-2).AddHours(-1),

            };
            var order4 = new Order()
            {
                Sender = sender4,
                Driver = driver4,
                Reciever = reciever4,
                DeliveryTax = 1,
                Employee = employee,
                OrderDescription = "اقلام",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "فردي",
                Tax = 3,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "2",
                Wieght = 5,
                Value = 100,
                FinancialStatus = Enums.FinancialStatus.Paid,
                DriverNotifyingTime = DateTime.Now.AddDays(-2).AddHours(-4),
                OrderCreationTime = DateTime.Now.AddDays(-6).AddHours(-6),
                OrderDateTime = DateTime.Now.AddDays(-7).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddDays(-2).AddHours(-2),
                PackageReceivingTime = DateTime.Now.AddDays(-2).AddHours(-4),

            };
            var order5 = new Order()
            {
                Sender = sender5,
                Driver = driver4,
                Reciever = reciever5,
                DeliveryTax = 10,
                Employee = employee,
                OrderDescription = "حقائب",
                MossaljiTaxDinnar = 2,
                MossaljiTaxPercentage = 3,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "شركات اونلاين",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.ZainCash,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.PendingDriver,
                DriverNotifyingTime = DateTime.Now.AddDays(-1).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddDays(-1).AddHours(-3),
                OrderDateTime = DateTime.Now.AddDays(-1).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddDays(-1).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddDays(-1).AddHours(-6),

            };
            var order6 = new Order()
            {
                Sender = sender2,
                Driver = driver1,
                Reciever = reciever1,
                DeliveryTax = 15,
                Employee = employee,
                OrderDescription = "احسن اكل",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "اكل",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.PendingDriver,
                DriverNotifyingTime = DateTime.Now.AddDays(-3).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddDays(-3).AddHours(-3),
                OrderDateTime = DateTime.Now.AddDays(-3).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddDays(-3).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddDays(-3).AddHours(-6),

            };
            var order7 = new Order()
            {
                Sender = sender3,
                Driver = driver1,
                Reciever = reciever5,
                DeliveryTax = 15,
                Employee = employee,
                OrderDescription = "ادوات مطبخ",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "ادوات مطبخ",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.PendingDriver,
                DriverNotifyingTime = DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-3),
                OrderDateTime = DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-6),

            };
            var order8 = new Order()
            {
                Sender = sender1,
                Driver = driver1,
                Reciever = reciever5,
                DeliveryTax = 15,
                Employee = employee,
                OrderDescription = "معجنات",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "اكل",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.PendingApp,
                DriverNotifyingTime = DateTime.Now.AddMonths(-2).AddDays(-1).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddMonths(-2).AddDays(-1).AddHours(-3),
                OrderDateTime = DateTime.Now.AddMonths(-2).AddDays(-1).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddMonths(-2).AddDays(-1).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddMonths(-2).AddDays(-1).AddHours(-6),

            };
            var order9 = new Order()
            {
                Sender = sender3,
                Driver = driver1,
                Reciever = reciever4,
                DeliveryTax = 15,
                Employee = employee,
                OrderDescription = "ادوات بناء",
                MossaljiTaxDinnar = 1,
                MossaljiTaxPercentage = 1,
                OrderStatus = Enums.OrderStatus.Active,
                OrderType = "ادوات بناء",
                Tax = 16,
                PaymentMethod = Enums.PaymentMethod.Others,
                Volume = "123",
                Wieght = 123,
                Value = 123,
                FinancialStatus = Enums.FinancialStatus.PendingApp,
                DriverNotifyingTime = DateTime.Now.AddMonths(-3).AddDays(-1).AddHours(-2),
                OrderCreationTime = DateTime.Now.AddMonths(-3).AddDays(-1).AddHours(-3),
                OrderDateTime = DateTime.Now.AddMonths(-3).AddDays(-1).AddHours(-4),
                PackageDeleveringTime = DateTime.Now.AddMonths(-3).AddDays(-1).AddHours(-5),
                PackageReceivingTime = DateTime.Now.AddMonths(-3).AddDays(-1).AddHours(-6),

            };

            context.Senders.AddRange(new List<Sender> { sender1, sender2, sender3, sender4, sender5 });
            context.Receivers.AddRange(new List<Reciever> { reciever1, reciever2, reciever3, reciever4, reciever5 });
            context.Drivers.AddRange(new List<Driver> { driver1, driver2, driver3, driver4 });
            context.Orders.AddRange(new List<Order> { order1, order2, order3, order4, order5, order6, order7, order8, order9 });

            #endregion

            #endregion

            base.Seed(context);
        }
    }
}
