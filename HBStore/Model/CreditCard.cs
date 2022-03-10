namespace HBStore.Model
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string HolderName { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public int  CVV { get; set; }
        public int? PaymentId { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}