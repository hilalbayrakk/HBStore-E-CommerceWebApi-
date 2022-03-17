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
             CityId =1 ,
             DistrictId = 1

         },
         new Address
         {
             Id = 2,
             Name = "İş",
             OpenAddress1 = "Soğanlık Yeni Mahallesi, Pamukkale Sokak, No:11",
             OpenAddress2 = "Marketin yanı",
              CityId =2,
             DistrictId = 2

         });
          modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                Name = "Sakarya"
            
            },
              new City
              {
                  Id = 2,
                  Name = "Istanbul"
        

              }
          );
         modelBuilder.Entity<District>().HasData(
          new District
          {
              Id = 1,
              Name = "Karasu",
              CityId = 1

          },
          new District
          {
              Id = 2,
              Name = "Kartal",
              CityId = 1

          });
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
              {
                  entity.HasKey(e => e.Id);
                  entity.Property(e => e.Name).IsRequired();
                  entity.Property(e => e.OpenAddress1);
                  entity.Property(e => e.OpenAddress2);
                   entity.HasOne(e => e.City).WithMany(e => e.Addresses).HasForeignKey(e => e.CityId);
                  entity.HasOne(e => e.District).WithMany(e => e!.Addresses).HasForeignKey(e => e!.DistrictId);
                    
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
               entity.HasOne(c => c.City).WithMany(c => c!.Districts).HasForeignKey(c => c.CityId);
           });

            SetDataToDB(modelBuilder);
        }
    }
}
