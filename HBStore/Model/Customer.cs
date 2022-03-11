namespace HBStore.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? ComplaintId { get; set; }
        public Complaint? Complaint { get; set; }
        public virtual ICollection<Complaint>? Complaints { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}