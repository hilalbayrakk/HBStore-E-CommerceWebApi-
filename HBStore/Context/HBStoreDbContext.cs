using HBStore.DatabaseBuilder;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Context
{
    public class HBStoreDbContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> City{ get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            optionsBuilder.UseMySql("server=localhost;database=hbstoredb;user=root;port=3306;password=toortoor", serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AccountDatabaseBuilder.TableBuilder(modelBuilder);
            AddressDatabaseBuilder.TableBuilder(modelBuilder);
            ComplaintDatabaseBuilder.TableBuilder(modelBuilder);
            CustomerDatabaseBuilder.TableBuilder(modelBuilder);
            OrderDatabaseBuilder.TableBuilder(modelBuilder);
            PaymentDatabaseBuilder.TableBuilder(modelBuilder);
            ProductDatabaseBuilder.TableBuilder(modelBuilder);
            SupplierDatabaseBuilder.TableBuilder(modelBuilder);
            UserDatabaseBuilder.TableBuilder(modelBuilder);

        }

    }
}


