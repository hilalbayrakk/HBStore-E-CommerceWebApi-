using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public static class CustomerDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Hilal",
                    LastName = "BAYRAK",
                    Email = "hilal@gmailcom",
                    Password = "12345",
                    GsmNumber = "05395679685"

                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Koray",
                    LastName = "BAYRAK",
                    Email = "koray@gmailcom",
                    Password = "54321",
                    GsmNumber = "05349435678"
                }
            );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.FirstName).IsRequired();
        entity.Property(e => e.LastName).IsRequired();
        entity.Property(e => e.Email).IsRequired();
        entity.Property(e => e.Password).IsRequired();
        entity.Property(e => e.GsmNumber).IsRequired();
        
        
    });
            SetDataToDB(modelBuilder);
        }
    }
}