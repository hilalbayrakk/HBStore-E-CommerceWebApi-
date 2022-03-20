namespace HBStore.Interface
{
    public interface IBasketRepository
    {
        Task<Product> AddProduct(Product product);
        Task DeleteProduct(Product product);
        Task<Basket> CreateBasket(Basket basket);
        Task DeleteBasket(Basket basket);
        Task<Basket> UpdateBasket(Basket basket);
        Task<List<Basket>> GetAllBasket();
        Task<Basket> GetBasketById(int basketId);
        Task<Basket> GetBasketByCustomerId(int customerId);
    }
}