namespace HBStore.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public int? ComplaintId { get; set; }
        public Complaint? Complaint { get; set; }
        public virtual ICollection<Complaint>? Complaints { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}