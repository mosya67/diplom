using Database.Db.EntityTypeConfig;
using Database.model;
using Microsoft.EntityFrameworkCore;

namespace Database.Db
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Order> Orders { get; set; }
        //DbSet<Role> Roles { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        //DbSet<Worker> Workers { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=db.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConf());
            modelBuilder.ApplyConfiguration(new DeviceConf());
            modelBuilder.ApplyConfiguration(new FaultConf());
            modelBuilder.ApplyConfiguration(new OrderConf());
            //modelBuilder.ApplyConfiguration(new RoleConf());
            modelBuilder.ApplyConfiguration(new SolutionConf());
            modelBuilder.ApplyConfiguration(new StatusConf());
            //modelBuilder.ApplyConfiguration(new WorkerConf());
        }
    }
}
