namespace HBStore.DatabaseBuilder
{
    public class AccountDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
             new Account
             {
                 Id = 1,
                 Email = "hilal@gmail.com",
                 Password = "123456",
                 IsBlocked = true,
                 Visibility = true
             },
             new Account
             {
                 Id = 2,
                 Email = "bayrak@gmail.com",
                 Password = "654321",
                 IsBlocked = true,
                 Visibility = true
             }
         );
            modelBuilder.Entity<Role>().HasData(
              new Role
              {
                  Id = 1,
                  Name = "admin"

              },
              new Role
              {
                  Id = 2,
                  Name = "user"

              }
          );
        }

        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.Email).IsRequired();
                 entity.Property(e => e.Password).IsRequired();
                 entity.Property(e => e.IsBlocked);
                 entity.Property(e => e.Visibility);
                 entity.HasMany(e => e.Role).WithMany(e => e.Account).UsingEntity(j => j.ToTable("Account_Role"));

             });

            modelBuilder.Entity<Role>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name).IsRequired();
           });

            SetDataToDB(modelBuilder);
        }
    }
}