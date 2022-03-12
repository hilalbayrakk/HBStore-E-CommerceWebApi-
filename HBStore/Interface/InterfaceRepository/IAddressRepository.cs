using HBStore.Model;

namespace HBStore.Interface.InterfaceRepository
{
    public interface IAddressRepository
    {
        Task<Address> RegisterAddress(Address address);
        Task<Address> GetAddress(int id);
        Task<List<Address>> GetAllAddress();
        Task<Address> DeleteAddress(int id);
        Task<Address> UpdateAddress(Address address);
        Task<City> CreateCity(City city);
        Task<City> FindCityByName(string CityName);
        Task<City> DeleteCity(City city);
        Task<District> CreateDistrict(District district);
        Task<District> FindDistrictByName(string DistrictName);
        Task<List<District>> GetAllDistrictsByCityId(int id);
        Task<District> DeleteDistrict(District district);

    }
}
