using HBStore.DTO;
using HBStore.Model;

namespace HBStore.Interface
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task<List<Product>> GetAllProduct();
        Task<Product> GetByProductId(int productId);
        Task<Product> GetProductByName(string productName);
        Task<List<Product>> GetAllProductByCategoryId(int categoryId);
        Task<List<Product>> GetAllProductByBrandId(int brandId);
        Task<List<Product>> GetAllProductByPriceASC(int price);
        Task<List<Product>> GetAllProductByPriceDESC(int price);
        Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice);
        List<ProductDetailsDTO> GetProductDetails();
        ProductDetailsDTO GetProductDetailByName(string name);


    }
}