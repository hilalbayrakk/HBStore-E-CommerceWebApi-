namespace HBStore.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        
       
    }
}