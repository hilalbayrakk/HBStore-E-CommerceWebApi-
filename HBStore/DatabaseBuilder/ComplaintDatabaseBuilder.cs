using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public class ComplaintDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Complaint>().HasData(
                new Complaint
                {
                    Id = 1,
                    Detail = "blablablablabla",
                   
                },
                new Complaint
                {
                    Id = 2,
                    Detail = "asdadfsgfgdfdzr",
                   
                }
            );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaint>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Detail).IsRequired();
        
    });
            SetDataToDB(modelBuilder);
        }
    }
}