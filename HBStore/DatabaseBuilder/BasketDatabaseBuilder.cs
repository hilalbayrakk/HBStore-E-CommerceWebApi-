namespace HBStore.DatabaseBuilder
{
    public static class BasketDatabaseBuilder
    {
        static void SetDataToDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
             new Basket
             {
                 Id = 1,
                 CustomerId = 1
             },
             new Basket
             {
                 Id = 2,
                 CustomerId = 2
             }
         );
           
        }

        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.CustomerId).IsRequired();

             });

           
            SetDataToDB(modelBuilder);
        }
    }
}