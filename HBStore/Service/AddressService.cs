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

        public async Task<Address> GetAddress(int id)
        {
            if (id != null)
            {
                return await _addressRepository.GetAddress(id);
            }
            return null;
        }

        public async Task<List<Address>> GetAllAddress()
        {
            return await _addressRepository.GetAllAddress();
        }

        public async Task<Address> RegisterAddress(Address address)
        {
            return await _addressRepository.RegisterAddress(address);
        }

        public async Task<Address> DeleteAddress(int id)
        {
            return await _addressRepository.DeleteAddress(id);
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            return await _addressRepository.UpdateAddress(address);
        }

        public async Task<City> CreateCity(City city)
        {
            var ExistCity = await _addressRepository.FindCityByName(city.Name);
            if (ExistCity == null)
            {
                return await _addressRepository.CreateCity(city);
            }
            throw new Exception();
        }

        public async Task<City> DeleteCity(City city)
        {
            var ExistCity = await _addressRepository.FindCityByName(city.Name);
            if(ExistCity != null)
            {
                return await _addressRepository.DeleteCity(city);
            }
            throw new Exception();
        }
        public async Task<District> CreateDistrict(District district)
        {
           var ExistDistrict = await _addressRepository.FindDistrictByName(district.Name);
           if(ExistDistrict == null)
           {
               return await _addressRepository.CreateDistrict(district);
           }
           throw new Exception();
        }

        public async Task<District> DeleteDistrict(District district)
        {
            var ExistDistrict = await _addressRepository.FindDistrictByName(district.Name);
            if(ExistDistrict != null)
            {
                return await _addressRepository.DeleteDistrict(district);
            }
            throw new Exception();
        }

        public async Task<List<District>> GetAllDistrictsByCityId(int id)
        {
            return await _addressRepository.GetAllDistrictsByCityId(id);
        }



    }
}