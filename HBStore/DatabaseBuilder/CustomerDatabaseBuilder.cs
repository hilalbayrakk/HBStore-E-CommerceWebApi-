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
                   
                },
                new Customer
                {
                    Id = 2,
                    
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