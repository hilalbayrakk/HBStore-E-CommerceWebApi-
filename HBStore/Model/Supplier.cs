namespace HBStore.Model
{
    public class Supplier
    {
        private double _rating;

        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Brand>? Brand { get; set; }
        public double Rating { get; set; }

        public bool IsVisibility { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Supplier()
        {
        }

        public Supplier(SupplierDTO supplierDTO)
        {
            this.Name = supplierDTO.Name;
            this.Account = supplierDTO.Account;
            this.Address = supplierDTO.Address;
            this.Brand = supplierDTO.Brand;
            this.Rating = supplierDTO.Rating;
            this.IsVisibility = supplierDTO.IsVisibility;
        }

    }
}