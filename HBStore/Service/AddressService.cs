using HBStore.Interface;
using HBStore.Model;

namespace HBStore.Service
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> RegisterAddress(Address address)
        {
            return await _addressRepository.RegisterAddress(address);
        }

        public async Task DeleteAddress(Address address)
        {
            var result = await _addressRepository.GetAddressById(address.Id);
            if (result != null)
            {
                await _addressRepository.DeleteAddress(address);
            }
            throw new Exception("Silinecek adres bulunamadi!");
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            return await _addressRepository.UpdateAddress(address);
        }

        public async Task<List<Address>> GetAllAddress()
        {
            return await _addressRepository.GetAllAddress();
        }

        public async Task<Address> GetAddressById(int id)
        {
            if (id != null)
            {
                return await _addressRepository.GetAddressById(id);
            }
            return null;
        }

        public async Task<City> CreateCity(City city)
        {
            var result = await _addressRepository.FindCityByName(city.Name);
            if (result == null)
            {
                return await _addressRepository.CreateCity(city);
            }
            throw new Exception("Bu isme sahip bir sehir mevcuttur!");
        }

        public async Task<City> DeleteCity(City city)
        {
            var result = await _addressRepository.FindCityByName(city.Name);
            if (result != null)
            {
                return await _addressRepository.DeleteCity(city);
            }
            throw new Exception("Silinecek sehir bulunamadi!");
        }
        public async Task<District> CreateDistrict(District district)
        {
            var result = await _addressRepository.FindDistrictByName(district.Name);
            if (result == null)
            {
                return await _addressRepository.CreateDistrict(district);
            }
            throw new Exception("Bu isme sahip bir ilce mevcuttur!");
        }

        public async Task<List<District>> GetAllDistrictsByCityId(int id)
        {
            return await _addressRepository.GetAllDistrictsByCityId(id);
        }

        public async Task<District> DeleteDistrict(District district)
        {
            var result = await _addressRepository.FindDistrictByName(district.Name);
            if (result != null)
            {
                return await _addressRepository.DeleteDistrict(district);
            }
            throw new Exception("Silinecek ilce bulunamadi!");
        }





    }
}