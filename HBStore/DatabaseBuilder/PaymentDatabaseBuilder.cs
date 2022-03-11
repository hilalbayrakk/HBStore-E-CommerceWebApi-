using HBStore.Model;
using Microsoft.EntityFrameworkCore;


namespace HBStore.DatabaseBuilder
{
    public static class PaymentDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Type = "Havale",
                    CardId = 1
                },
                new Payment
                {
                    Id = 2,
                    Type = "Kredi Kartı",
                    CardId = 2
                });
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Type).IsRequired();
        entity.HasOne(e => e.CreditCard).WithMany(e => e!.Payments).HasForeignKey(e => e.CardId);
    });

            SetDataToDB(modelBuilder);

        }
    }
}