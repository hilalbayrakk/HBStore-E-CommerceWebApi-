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

            modelBuilder.Entity<CreditCard>().HasData(
                 new CreditCard
                 {
                    Id = 1,
                    CardNumber = "111111111111111111111111111",
                    HolderName = "Hilal BAYRAK",
                    ExpireMonth = "11",
                    ExpireYear = "27",
                    CVV = 123

                    },
                    new CreditCard
                    {
                        Id = 2,
                        CardNumber = "2222222222222222222222222222",
                        HolderName = "Koray BAYRAK",
                        ExpireMonth = "10",
                        ExpireYear = "27",
                        CVV = 456
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
            modelBuilder.Entity<CreditCard>(entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.CardNumber).IsRequired();
                   entity.Property(e => e.HolderName).IsRequired();
                   entity.Property(e => e.ExpireMonth).IsRequired();
                   entity.Property(e => e.ExpireYear).IsRequired();
                   entity.Property(e => e.CVV).IsRequired();

               });
            SetDataToDB(modelBuilder);

        }
    }
}