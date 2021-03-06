using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public static class UserDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "hilalbayrak",
                    FirstName = "Hilal",
                    LastName = "BAYRAK",
                    Email = "hilal.bayrak@gmailcom",
                    Password = "123456",
                    GsmNumber = "05395679685"

                },
                new User
                {
                    Id = 2,
                    UserName = "koraybayrak",
                    FirstName = "Koray",
                    LastName = "BAYRAK",
                    Email = "koray.bayrak@gmailcom",
                    Password = "654321",
                    GsmNumber = "05349435678"
                }
            );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.UserName).IsRequired();
        entity.Property(e => e.FirstName).IsRequired();
        entity.Property(e => e.LastName).IsRequired();
        entity.Property(e => e.Email).IsRequired();
        entity.Property(e => e.Password).IsRequired();
        entity.Property(e => e.GsmNumber).IsRequired();
        entity.Property(e => e.BirthDate);
        entity.HasOne(p => p.Account).WithMany(c => c!.Users).HasForeignKey(p => p.AccountId);
        entity.HasOne(p => p.Gender).WithOne(c => c!.User).HasForeignKey<User>(p => p.GenderId);


    });
            SetDataToDB(modelBuilder);
        }
    }
}

