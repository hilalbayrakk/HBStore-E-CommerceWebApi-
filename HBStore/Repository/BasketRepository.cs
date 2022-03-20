namespace HBStore.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly HBStoreDbContext _context;

        public BasketRepository(HBStoreDbContext context)
        {
            _context = context;

        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            var result = _context.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task<Basket> CreateBasket(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

        public async Task DeleteBasket(Basket basket)
        {
            var result = _context.Remove(basket);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Basket>> GetAllBasket()
        {
            return await _context.Baskets.ToListAsync();
        }

        public async Task<Basket> GetBasketById(int basketId)
        {
            return await _context.Baskets.FirstOrDefaultAsync(x => x.Id == basketId);
        }

        public async Task<Basket> GetBasketByCustomerId(int customerId)
        {
            return await _context.Baskets.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }

        public async Task<Basket> UpdateBasket(Basket basket)
        {
            var result = _context.Update(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

    }
}