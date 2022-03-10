namespace HBStore.Model
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<Supplier>? Suppliers { get; set; }

    }
}