using HBStore.Model;

namespace HBStore.DTO
{

    public class SupplierDTO
    {
        public string? Name { get; set; }
        public Account? Account { get; set; }
        public Address? Address { get; set; }
        public ICollection<Brand>? Brand { get; set; }
        public double Rating { get; set; }
        public bool IsVisibility { get; set; }


        public SupplierDTO()
        {

        }

        public SupplierDTO(Supplier supplier)
        {
            if (supplier != null)
            {
                this.Name = supplier.Name;
                this.Account = supplier.Account;
                this.Address = supplier.Address;
                this.Brand = supplier.Brand;
                this.Rating = supplier.Rating;
                this.IsVisibility = supplier.IsVisibility;
            }
        }


        public SupplierDTO(string name, Account account, Address address, ICollection<Brand> brand, double rating, bool IsVisibility)
        {

            this.Name = name;
            this.Account = account;
            this.Address = address;
            this.Brand = brand;
            this.Rating = rating;
            this.IsVisibility = IsVisibility;

        }

    }
}