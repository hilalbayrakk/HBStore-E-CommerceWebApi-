using HBStore.Interface;
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
        public async Task<Brand> AddBrand(Brand brand)
        {
            var result = await _brandRepository.GetByBrandName(brand.Name);
            if(result == null)
            {
                await _brandRepository.AddBrand(brand);
                return brand;
            }
            throw new InvalidOperationException("Bu isimde bir marka bulunmaktadir!");
        }

        public async Task DeleteBrand(Brand brand)
        {
            var result = await _brandRepository.GetByBrandId(brand.Id);
            if(result != null)
            {
                await _brandRepository.DeleteBrand(brand);
            }
            throw new Exception("Silinecek marka bulunamadi!");
        }

        public async Task<Brand> UpdateBrand (Brand brand, int id)
        {
            var result = await _brandRepository.GetByBrandId(id);
            if(result != null)
            {
                return await _brandRepository.UpdateBrand(result);
            }
           throw new InvalidOperationException("Boyle bir marka bulunmamaktadir!");
        }
        public async Task<List<Brand>> GetAllBrand()
        {
            return await _brandRepository.GetAllBrand();
        }

        public async Task<Brand> GetByBrandId(int brandId)
        {
            return await _brandRepository.GetByBrandId(brandId);
        }

        public async Task<Brand> GetByBrandName(string brandName)
        {
            return await _brandRepository.GetByBrandName(brandName);
        }

    }
}