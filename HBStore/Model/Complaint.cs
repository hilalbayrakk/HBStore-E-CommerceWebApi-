namespace HBStore.Model
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }   
        public virtual ICollection<Customer>? Customers { get; set; }
    }
}