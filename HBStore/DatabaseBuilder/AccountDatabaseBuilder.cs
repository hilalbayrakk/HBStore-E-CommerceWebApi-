namespace HBStore.DatabaseBuilder
{
    public static class AccountDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
             new Account
             {
                 Id = 3,
                 Email = "hilal.bayrak@gmail.com",
                 Password = "123456",
                 Visibility = true
             },
             new Account
             {
                 Id = 4,
                 Email = "koray.bayrak@gmail.com",
                 Password = "654321",
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