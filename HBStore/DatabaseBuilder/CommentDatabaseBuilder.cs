using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.DatabaseBuilder
{
    
    public static class CommentDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Comment>().HasData(
                 new Comment
                  {
                      Id = 1,
                      Description = "Çok güzel",
                      IsActive = true,
                      CustomerId = 1,
                      ProductId = 1
                  },
                   new Comment
                   {
                       Id = 2,
                       Description = "Çok çirkin",
                       IsActive = true,
                       CustomerId = 2,
                       ProductId = 2
                   }
              );
        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.Description).IsRequired();
                 entity.Property(e => e.IsActive);
                 entity.Property(e => e.CommentDate);
                 entity.HasOne(p => p.Customer).WithMany(c => c!.Comments).HasForeignKey(p => p.CustomerId);
                 entity.HasOne(p => p.Product).WithMany(c => c!.Comments).HasForeignKey(p => p.ProductId);
             });
            SetDataToDB(modelBuilder);

        }
    }
}
