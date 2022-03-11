using HBStore.Model;

namespace HBStore.Interface.InterfaceRepository
{
    public interface IAddressRepository
    {
        Task<Address> RegisterAddress(Address address);
        Task<List<Address>> GetAllAddress();
        Task<Address> GetAddress(int id);
        Task<Address> UpdateAddress(Address address);
        Task<Address> DeleteAddress(int id);
        Task<City> FindCityByName(string CityName);
        Task<City> CreateCity(City city);
        Task<District> CreateDistrict(District district);
        Task<District> FindDistrictByName(string DistrictName);
        Task<List<District>> GetAllDistrictsByCityId(int id);
        Task<City> DeleteCity(City city);
        Task<District> DeleteDistrict(District district);

    }
}
