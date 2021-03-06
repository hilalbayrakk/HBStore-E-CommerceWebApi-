using HBStore.DTO;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.AspNetCore.Mvc;

namespace HBStore.Service
{
    public class ProductService : ControllerBase, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var result = await _productRepository.GetProductByName(product.Name);
            if (result == null)
            {
                return await _productRepository.AddProduct(product);
            }
            return BadRequest("Aynı isimde baska bir urun bulunuyor!");
        }

        public async Task DeleteProduct(Product product)
        {
            var result = _productRepository.GetByProductId(product.Id);
            if (result != null)
            {
                await _productRepository.DeleteProduct(product);
            }
            throw new Exception("Silinecek urun bulunamadi!");
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            var updatedProduct = await _productRepository.GetByProductId(id);
            if(updatedProduct != null)
            {
                updatedProduct = product;
                await _productRepository.UpdateProduct(product);
                return product;
            }
            return BadRequest("Guncellenecek urun bulunamadi!");
        }

        public async Task<Product> GetProductByName(string productName)
        {
           var result = _productRepository.GetProductByName(productName);
           if(result != null)
           {
                return await result;
           }
           throw new InvalidOperationException("Bu isimde bir urun bulunamadi!");
        }

        public async Task<Product> GetByProductId(int productId)
        {
           return await _productRepository.GetByProductId(productId);
        }

        public async Task<List<Product>> GetAllProductByBrandId(int brandId)
        {
            return await _productRepository.GetAllProductByBrandId(brandId);
        }

        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            return await _productRepository.GetAllProductByCategoryId(categoryId);
        }

        public async Task<List<Product>> GetAllProductByPriceASC(int price)
        {
            return await _productRepository.GetAllProductByPriceASC(price);
        }

        public async Task<List<Product>> GetAllProductByPriceDESC(int price)
        {
            return await _productRepository.GetAllProductByPriceDESC(price);
        }

        public async Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice)
        {
            return await _productRepository.GetAllProductByPriceRange(minPrice,maxPrice);
        }

        public async Task<ProductDetailsDTO> GetProductDetailByName(string name)
        {
            return _productRepository.GetProductDetailByName(name);
        }

        public async Task<List<ProductDetailsDTO>> GetProductDetails()
        {
            return _productRepository.GetProductDetails();
        }

    }
}