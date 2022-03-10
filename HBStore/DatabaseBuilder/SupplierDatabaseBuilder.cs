using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public static class SupplierDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    Id = 1,
                    Name = "SkyFly Group"
                },
                new Supplier
                {
                    Id = 2,
                    Name = "White Group"
                }
            );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).IsRequired();
        entity.HasOne(e => e.Company).WithMany(e => e.Brands).HasForeignKey(e => e.CompanyId);
    });
            SetDataToDB(modelBuilder);
        }
    }
}