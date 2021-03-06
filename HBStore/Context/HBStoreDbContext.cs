namespace HBStore.Context
{
    public class HBStoreDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Address { get; set; }
         public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
         public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Incidence>? Incidences { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
          public DbSet<Role>? Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
         public DbSet<User> Users { get; set; }
         


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
            BasketDatabaseBuilder.TableBuilder(modelBuilder);
            CommentDatabaseBuilder.TableBuilder(modelBuilder);
            ComplaintDatabaseBuilder.TableBuilder(modelBuilder);
            CustomerDatabaseBuilder.TableBuilder(modelBuilder);
            GenderDatabaseBuilder.TableBuilder(modelBuilder);
            OrderDatabaseBuilder.TableBuilder(modelBuilder);
            PaymentDatabaseBuilder.TableBuilder(modelBuilder);
            ProductDatabaseBuilder.TableBuilder(modelBuilder);
            SupplierDatabaseBuilder.TableBuilder(modelBuilder);
            UserDatabaseBuilder.TableBuilder(modelBuilder);

        }

    }
}


