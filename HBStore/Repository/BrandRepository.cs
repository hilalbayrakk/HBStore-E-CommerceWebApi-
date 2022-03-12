using HBStore.Context;
using HBStore.Interface.InterfaceRepository;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly HBStoreDbContext _context;

        public BrandRepository(HBStoreDbContext context)
        {
            _context = context;

        }
        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteBrandAsync(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }


        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<List<Brand>> GetAllBrandAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetByBrandIdAsync(int brandId)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == brandId);
        }

        public async Task<Brand> GetByBrandNameAsync(string brandName)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Name == brandName);
        }

    }
}