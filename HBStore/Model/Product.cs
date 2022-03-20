namespace HBStore.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int QuantityPerUnit { get; set; }


        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Supplier>? Suppliers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}