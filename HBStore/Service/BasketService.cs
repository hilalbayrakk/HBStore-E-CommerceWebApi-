namespace HBStore.Service
{
    public class BasketService : ControllerBase, IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

         private readonly IProductRepository _productRepository;
         public BasketService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            
            var result = await _productRepository.GetByProductId(product.Id);
            if (result != null)
            {
                return await _basketRepository.AddProduct(product);
            }
            return BadRequest("Sepette aynı Id'ye sahip bir urun bulunuyor!");
        }
        public async Task DeleteProduct(Product product)
        {
            var result = _productRepository.GetByProductId(product.Id);
            if (result != null)
            {
                await _basketRepository.DeleteProduct(product);
            }
            throw new Exception("Sepette silinecek urun bulunamadi!");
        }
        public async Task<ActionResult<Basket>> CreateBasket(Basket basket)
        {
            var result = await _basketRepository.GetBasketById(basket.Id);
            if (result != null)
            {
                return await _basketRepository.CreateBasket(basket);
            }
            return BadRequest("Aynı Id'ye sahip bir sepet bulunuyor!");
        }

        public async Task DeleteBasket(Basket basket)
        {
            var result = _basketRepository.GetBasketById(basket.Id);
            if (result != null)
            {
                await _basketRepository.DeleteBasket(basket);
            }
            throw new Exception("Silinecek sepet bulunamadi!");
        }

        public async Task<List<Basket>> GetAllBasket()
        {
            return await _basketRepository.GetAllBasket();
        }
        public async Task<Basket> GetBasketById(int basketId)
        {
            return await _basketRepository.GetBasketById(basketId);
        }
        public async Task<Basket> GetBasketByCustomerId(int customerId)
        {
            return await _basketRepository.GetBasketByCustomerId(customerId);
        }

        public async Task<ActionResult<Basket>> UpdateBasket(Basket basket, Product product)
        {
            var result = await _basketRepository.GetBasketById(product.Id);
            if(result != null)
            {
                result = basket;
                await _basketRepository.UpdateBasket(basket);
                return basket;
            }
            return BadRequest("Guncellenecek sepet bulunamadi!");
        }

           }
}