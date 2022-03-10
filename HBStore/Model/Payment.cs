namespace HBStore.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public int? CardId { get; set; }
        public CreditCard? CreditCard { get; set; }

    }
}