using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public static class AddressDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>().HasData(
         new Address
         {
             Id = 1,
             Name = "Ev",
             OpenAddress1 = "Gülsuyu Mahallesi, 134. Sokak, No:4, Kat:3",
             OpenAddress2 = "Caminin arkası",
             DistrictId = 1

         },
         new Address
         {
             Id = 2,
             Name = "İş",
             OpenAddress1 = "Soğanlık Yeni Mahallesi, Pamukkale Sokak, No:11",
             OpenAddress2 = "Marketin yanı",
             DistrictId = 2

         });
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
              {
                  entity.HasKey(e => e.Id);
                  entity.Property(e => e.Name).IsRequired();
                  entity.Property(e => e.OpenAddress1);
                  entity.Property(e => e.OpenAddress1);
                  entity.HasOne(e => e.District).WithMany(e => e.Addresses).HasForeignKey(e => e.DistrictId);

              });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<District>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name);
               entity.HasOne(c => c.City).WithMany(c => c.District).HasForeignKey(c => c.CityId);
           });

            SetDataToDB(modelBuilder);
        }
    }
}
