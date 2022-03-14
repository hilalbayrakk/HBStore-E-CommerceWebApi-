using HBStore.Model;

namespace HBStore.Interface
{
    public interface IAddressService
    {
        Task<Address> GetAddress(int id);
        Task<List<Address>> GetAllAddress();
        Task<Address> RegisterAddress(Address address);
        Task<Address> DeleteAddress(int id);
        Task<Address> UpdateAddress(Address address);
        Task<City> CreateCity(City city);
        Task<City> DeleteCity(City city);
        Task<District> CreateDistrict(District district);
        Task<List<District>> GetAllDistrictsByCityId(int id);
        Task<District> DeleteDistrict(District district);


    }
}