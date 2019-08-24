using Mossalji.Data.DataModels;
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
        public virtual DbSet<Reciver> Receivers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (!Database.Exists())
                Database.SetInitializer(new DbInitializer());
            base.OnModelCreating(modelBuilder);
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
            base.Seed(context);
        }
    }
}
