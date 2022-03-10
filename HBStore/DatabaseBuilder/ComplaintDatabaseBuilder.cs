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
                    CustomerId = 1
                },
                new Complaint
                {
                    Id = 2,
                    Detail = "asdadfsgfgdfdzr",
                    CustomerId = 2
                }
            );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaint>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Detail).IsRequired();
        entity.HasOne(e => e.Customer).WithMany(e => e!.Complaints).HasForeignKey(e => e.CustomerId);
    });
            SetDataToDB(modelBuilder);
        }
    }
}