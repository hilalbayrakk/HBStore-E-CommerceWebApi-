using HBStore.Model;
using Microsoft.AspNetCore.Mvc;
using HBStore.Interface;
using HBStore.DTO;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<Product> Add(Product product)
        {
            await _productService.AddProduct(product);
            return product;
        }
        [HttpPut("delete")]
        public async Task TaskDelete(Product product)
        {
            await _productService.DeleteProduct(product);

        }
        [HttpPut("update")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            var result = await _productService.UpdateProduct(id, product);
            return result;

        }

        [HttpGet("getall")]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAllProduct();
        }
        [HttpGet("getallbybrand")]
        public async Task<List<Product>> GetAllProductByBrandId(int brandId)
        {
            return await _productService.GetAllProductByBrandId(brandId);
        }
        [HttpGet("getallbycategory")]
        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            return await _productService.GetAllProductByCategoryId(categoryId);
        }
        [HttpGet("getallbypriceasc")]
        public async Task<List<Product>> GetAllProductByPriceASC(int price)
        {
            return await _productService.GetAllProductByPriceASC(price);
        }
        [HttpGet("getallbypricedesc")]
        public async Task<List<Product>> GetAllProductByPriceDESC(int price)
        {
            return await _productService.GetAllProductByPriceDESC(price);
        }
        [HttpGet("getallbypricemaxmin")]
        public async Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice)
        {
            return await _productService.GetAllProductByPriceRange(minPrice, maxPrice);
        }
        [HttpGet("getbyid")]
        public async Task<Product> GetByProductId(int productId)
        {
            var result = await _productService.GetByProductId(productId);
            return result;
        }
        [HttpGet("getbyname")]
        public async Task<Product> GetByName(string productName)
        {
            var result = await _productService.GetProductByName(productName);
            return result;
        }

        [HttpGet("productdetail")]
        public async Task<List<ProductDetailsDTO>> GetProductDetails()
        {
            return await _productService.GetProductDetails();
        }

        [HttpGet("productdetailbyname")]
        public async Task<ProductDetailsDTO> GetProductDetailByName(string name)
        {
            return await _productService.GetProductDetailByName(name);
        }
    }
}