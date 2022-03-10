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
             OpenAddress = "Gülsuyu Mahallesi, 134. Sokak, No:4, Kat:3",
             CountryId = 1,
             CityId = 1,
             DistrictId = 1

         },
         new Address
         {
             Id = 2,
             Name = "İş",
             OpenAddress = "Soğanlık Yeni Mahallesi, Pamukkale Sokak, No:11",
             CountryId = 2,
             CityId = 2,
             DistrictId = 2

         });

            modelBuilder.Entity<Country>().HasData(
        new Country
        {
            Id = 1,
            Name = "Turkey",
            Code = 001,
            HasState = false

        },
        new Country
        {
            Id = 2,
            Name = "Germany",
            Code = 002,
            HasState = true

        });


            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Sakarya",
                    CountryId = 1,



                },
                  new City
                  {
                      Id = 2,
                      Name = "Istanbul",
                      CountryId = 1,


                  });



            modelBuilder.Entity<State>().HasData(
               new State
               {
                   Id = 1,
                   Name = "New York",
                   CountryId = 2

               },

               new State
               {
                   Id = 2,
                   Name = "California",
                   CountryId = 2

               });
            
        
            modelBuilder.Entity<District>().HasData(
              new District
              {
                  Id = 1,
                  Name = "Maltepe",
                  CityId = 1

              },
              new District
              {
                  Id = 2,
                  Name = "Kartal",
                  CityId = 1


              }
           );
        }
         public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
              {
                  entity.HasKey(e => e.Id);
                  entity.Property(e => e.Name).IsRequired();
                  entity.Property(e => e.OpenAddress);
                  entity.HasOne(e => e.City).WithMany(e => e.Addresses).HasForeignKey(e => e.CityId);
                  entity.HasOne(e => e.Country).WithMany(e => e.Addresses).HasForeignKey(e => e.CountryId);
                  entity.HasOne(e => e.District).WithMany(e => e.Addresses).HasForeignKey(e => e.DistrictId);
                  entity.HasOne(e => e.State).WithMany(e => e.Addresses).HasForeignKey(e => e.StateId);


              });
            modelBuilder.Entity<Country>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name).IsRequired();
               entity.Property(e => e.Code);
               entity.Property(e => e.HasState);
           });

            modelBuilder.Entity<State>(entity =>
             {
                 entity.HasKey(e => e.Id);

                 entity.Property(e => e.Name).IsRequired();
                 entity.HasOne(e => e.Country).WithMany(c => c.state).HasForeignKey(e => e.CountryId);

             });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.HasOne(c => c!.Country).WithMany(c => c!.city).HasForeignKey(c => c.CountryId);
                entity.HasOne(c => c.State).WithMany(c => c.city).HasForeignKey(c => c.StateId);

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
