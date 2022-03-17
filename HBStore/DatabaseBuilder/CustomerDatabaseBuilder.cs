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
                    Name = "Hilal",
                    UserId = 1,
                    OrderId = 1,
                    ComplaintId = 1

                },
                new Customer
                {
                    Id = 2,
                    Name = "Koray",
                    UserId = 2,
                    OrderId =2,
                    ComplaintId = 2
                    

                }
            );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).IsRequired();
        entity.HasOne(e=>e.User).WithMany(e=>e.Customers).HasForeignKey(e=> e.UserId);
        entity.HasOne(e=>e.Order).WithMany(e=>e.Customers).HasForeignKey(e=> e.OrderId);
        entity.HasOne(e=>e.Complaint).WithMany(e=>e.Customers).HasForeignKey(e=> e.ComplaintId);

    });
            SetDataToDB(modelBuilder);
        }
    }
}