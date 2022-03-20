namespace HBStore.Model
{
    public class Basket
    {
        public int Id { get; set; }       
        public int CustomerId { get; set; }
        public List <Product> Products { get; set; }
    }
}