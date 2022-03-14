using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface IBrandService
    {
        Task<Brand> AddBrand(Brand brand);
        Task DeleteBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand brand,int id );
        Task<List<Brand>> GetAllBrand();
        Task<Brand> GetByBrandId(int brandId);
        Task<Brand> GetByBrandName(string brandName);
    }
}