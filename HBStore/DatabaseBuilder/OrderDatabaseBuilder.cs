using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public static class OrderDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
             new Order
             {
                 Id = 1,
                 Name = "Kıyafet Siparişi",
                 ProductId = 1,
                 CustomerId = 1,
                 PaymentId = 1

             },
             new Order
             {
                 Id = 2,
                 Name = "Elektronik Alet Siparişi",
                 ProductId = 2,
                 CustomerId = 2,
                 PaymentId = 2
             });
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.Name).IsRequired();
                 entity.HasOne(e => e.Payment).WithMany(e => e!.Orders).HasForeignKey(e => e.PaymentId);
             });
            SetDataToDB(modelBuilder);
        }
    }
}