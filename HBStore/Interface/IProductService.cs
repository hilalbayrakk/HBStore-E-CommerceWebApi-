namespace HBStore.Interface
{
    public interface IProductService
    {
        Task<ActionResult<Product>> AddProduct(Product product);
        Task<ActionResult<Product>> UpdateProduct(int id, Product product);
        Task DeleteProduct(Product product);
        Task<List<Product>> GetAllProduct();
        Task<Product> GetByProductId(int productId);
        Task<Product> GetProductByName(string productName);
        Task<List<Product>> GetAllProductByCategoryId(int categoryId);
        Task<List<Product>> GetAllProductByBrandId(int brandId);
        Task<List<Product>> GetAllProductByPriceASC(int price);
        Task<List<Product>> GetAllProductByPriceDESC(int price);
        Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice);
        Task<List<ProductDetailsDTO>> GetProductDetails();
        Task<ProductDetailsDTO> GetProductDetailByName(string name);


    }

}
