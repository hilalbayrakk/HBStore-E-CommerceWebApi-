using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public class GenderDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
              new Gender
              {
                  Id = 1,
                  Name = "Kız"
              },
               new Gender
               {
                   Id = 2,
                   Name = "Erkek"
               }
          );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name).IsRequired();
           });
            SetDataToDB(modelBuilder);
        }
    }
}
