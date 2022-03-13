namespace HBStore.Model
{
    public class Customer
    {
        public int Id { get; set; }
         public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? ComplaintId { get; set; }
        public virtual Complaint? Complaint { get; set; }
        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
        
    }
}