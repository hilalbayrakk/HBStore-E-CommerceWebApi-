namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]

    public class BasketController : ControllerBase
    {
         private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

         private readonly IProductService _productService;

        public BasketController(IProductService productService)
        {
            _productService = productService;
        }

         [HttpPost ("addproduct")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            return await _productService.AddProduct(product);
        }

        [HttpDelete ("deleteproduct")]
        public async Task DeleteProduct(Product product)
        {
            await _productService.DeleteProduct(product);
        }

        [HttpPost ("createbasket")]
        public async Task<ActionResult<Basket>> CreateBasket(Basket basket)
        {
            return await _basketService.CreateBasket(basket);
        }

        [HttpDelete ("deleteproduct")]
        public async Task DeleteBasket(Basket basket)
        {
            await _basketService.DeleteBasket(basket);
        }
        [HttpPut ("updateproduct")]
        public async Task<ActionResult<Basket>> UpdateBasket([FromQuery] Basket basket, Product product)
        {
            return await _basketService.UpdateBasket(basket, product);
        }

        [HttpGet ("getall")]
        public async Task<List<Basket>> GetAllBasket()
        {
            return await _basketService.GetAllBasket();

        }
        [HttpGet("getbyid")]
        public async Task<Basket> GetBasketById(int basketId)
        {
            return await _basketService.GetBasketById(basketId);
        }

        [HttpGet("getbycustomer id")]
        public async Task<Basket> GetBasketByCustomerId(int customerId)
        {
            return await _basketService.GetBasketByCustomerId(customerId);
        }
    }
}