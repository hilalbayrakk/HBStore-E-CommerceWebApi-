using HBStore.Context;
using HBStore.DTO;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HBStoreDbContext _context;

        public ProductRepository(HBStoreDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            var result = _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByProductId(int productId)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<Product> GetProductByName(string productName)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Name == productName);
            return result;
        }

        public async Task<List<Product>> GetAllProductByBrandId(int brandId)
        {
            return await _context.Products.Where(x => x.BrandId == brandId).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductByPriceASC(int price)
        {
            return await _context.Products.OrderBy(x => x.UnitPrice).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductByPriceDESC(int price)
        {
            return await _context.Products.OrderByDescending(x => x.UnitPrice).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice)
        {
            return await _context.Products.Where(x => x.UnitPrice >= minPrice && x.UnitPrice <= maxPrice).ToListAsync();
        }

        public List<ProductDetailsDTO> GetProductDetails()
        {
            using (HBStoreDbContext context = new HBStoreDbContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.Id
                             join brand in context.Brands
                             on product.BrandId equals brand.Id
                             join company in context.Companies
                             on product.CompanyId equals company.Id
                             select new ProductDetailsDTO()
                             {
                                 ProductName = product.Name,
                                 UnitPrice = product.UnitPrice,
                                 UnitsInStock = product.UnitsInStock,
                                 CategoryName = category.Name,
                                 BrandName = brand.Name,
                                 CompanyName = company.Name
                             };
                return result.ToList();
            }
        }
        public ProductDetailsDTO GetProductDetailByName(string name)
        {
            return GetProductDetails().FirstOrDefault(x => x.ProductName == name);
        }

    }
}