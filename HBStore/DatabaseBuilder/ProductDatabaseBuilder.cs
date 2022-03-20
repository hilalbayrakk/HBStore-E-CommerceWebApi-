using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    public static class ProductDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Clothes"
                },
                new Category
                {
                    Id = 2,
                    Name = "Electronic"
                }
    
                
            );
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "LC Waikiki Şirketi",
                    AddressId = 1
                },
                new Company
                {
                    Id = 2,
                    Name = "Apple Şirketi",
                    AddressId = 2
                }
            );
            modelBuilder.Entity<Brand>().HasData(
            new Brand
            {
                Id = 1,
                Name = "LC Waikiki",
                CompanyId = 1
            },
            new Brand
            {
                Id = 2,
                Name = "Apple",
                CompanyId = 2
            }
        );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Jean",
                    UnitPrice = 15,
                    UnitsInStock = 10,
                    BrandId = 1,
                    CategoryId = 1,
                    CompanyId = 1,
                    BasketId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Mobil Phone",
                    UnitPrice = 10,
                    UnitsInStock = 15,
                    BrandId = 2,
                    CategoryId = 2,
                    CompanyId = 2, 
                    BasketId = 2
                }
            );

        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).IsRequired();
        entity.HasOne(e => e.Company).WithMany(e => e.Brands).HasForeignKey(e => e.CompanyId);
    });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e => e.Address).WithOne(e => e.Company).HasForeignKey<Company>(e => e.AddressId);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e => e.Category).WithMany(e => e!.Products).HasForeignKey(e => e.CategoryId);
                entity.HasOne(e => e.Brand).WithMany(e => e!.Products).HasForeignKey(e=> e.BrandId);
                entity.HasOne(e => e.Basket).WithMany(e => e!.Products).HasForeignKey(e=> e.BasketId);
            });

            SetDataToDB(modelBuilder);
        }
    }
}