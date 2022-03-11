namespace HBStore.Model
{
    public class Company
    {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }

    public virtual ICollection<Brand>? Brands { get; set; }
    public virtual ICollection<Supplier>? Suppliers { get; set; }
    }
}