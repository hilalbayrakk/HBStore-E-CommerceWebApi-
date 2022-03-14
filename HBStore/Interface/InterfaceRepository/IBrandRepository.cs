using HBStore.Model;

namespace HBStore.Interface.InterfaceRepository
{
    public interface IBrandRepository
    {
        Task<Brand> AddBrand(Brand brand);
        Task DeleteBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand brand);
        Task<List<Brand>> GetAllBrand();
        Task<Brand> GetByBrandId(int brandId);
        Task<Brand> GetByBrandName(string brandName);
    }
}