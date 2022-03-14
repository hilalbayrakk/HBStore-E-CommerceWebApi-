using HBStore.Context;
using HBStore.Interface;
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
        public async Task<Brand> AddBrand(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }


        public async Task<Brand> UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<List<Brand>> GetAllBrand()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetByBrandId(int brandId)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == brandId);
        }

        public async Task<Brand> GetByBrandName(string brandName)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Name == brandName);
        }

    }
}