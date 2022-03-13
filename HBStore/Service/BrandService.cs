using HBStore.Interface.InterfaceRepository;
using HBStore.Interface.InterfaceService;
using HBStore.Model;

namespace HBStore.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository _brandRepository)
        {
            this._brandRepository = _brandRepository;
        }
        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            var result = await _brandRepository.GetByBrandNameAsync(brand.Name);
            if(result == null)
            {
                await _brandRepository.AddBrandAsync(brand);
                return brand;
            }
            throw new InvalidOperationException("Bu isimde bir marka bulunmaktadir!");
        }

        public async Task DeleteBrandAsync(Brand brand)
        {
            var deleteBrand = await _brandRepository.GetByBrandIdAsync(brand.Id);
            if(deleteBrand != null)
            {
                await _brandRepository.DeleteBrandAsync(brand);
            }
            throw new Exception("Silinecek marka bulunamadi!");
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
            var updatedBrand = await _brandRepository.GetByBrandIdAsync(brand.Id);
            if(updatedBrand != null)
            {
                return await _brandRepository.UpdateBrandAsync(updatedBrand);
            }
           throw new InvalidOperationException("Boyle bir marka bulunmamaktadir!");
        }
        public async Task<List<Brand>> GetAllBrandAsync()
        {
            return await _brandRepository.GetAllBrandAsync();
        }

        public async Task<Brand> GetByBrandIdAsync(int brandId)
        {
            return await _brandRepository.GetByBrandIdAsync(brandId);
        }

        public async Task<Brand> GetByBrandNameAsync(string brandName)
        {
            return await _brandRepository.GetByBrandNameAsync(brandName);
        }

    }
}