namespace HBStore.Interface
{
    public interface IAddressService
    { 
        Task<Address> RegisterAddress(Address address);
        Task DeleteAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task<List<Address>> GetAllAddress();
        Task<Address> GetAddressById(int id);
        Task<City> CreateCity(City city);
        Task<City> DeleteCity(City city);
        Task<District> CreateDistrict(District district);
        Task<List<District>> GetAllDistrictsByCityId(int id);
        Task<District> DeleteDistrict(District district);


    }
}