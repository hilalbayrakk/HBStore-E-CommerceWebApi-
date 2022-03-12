using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface IBrandService
    {
        Task<Brand> AddBrandAsync(Brand brand);
        Task DeleteBrandAsync(Brand brand);
        Task<Brand> UpdateBrandAsync(Brand brand);
        Task<List<Brand>> GetAllBrandAsync();
        Task<Brand> GetByBrandIdAsync(int brandId);
        Task<Brand> GetByBrandNameAsync(string brandName);
    }
}