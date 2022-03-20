namespace HBStore.Interface
{
    public interface IBasketService
    {

        Task<ActionResult<Product>> AddProduct(Product product);
        Task DeleteProduct(Product product);
        Task<ActionResult<Basket>> CreateBasket(Basket basket);
        Task DeleteBasket(Basket basket);
        Task<ActionResult<Basket>> UpdateBasket(Basket basket);
        Task<List<Basket>> GetAllBasket();
        Task<Basket> GetBasketById(int basketId);
        Task<Basket> GetBasketByCustomerId(int customerId);
    }
}