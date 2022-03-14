using HBStore.Model;
using Microsoft.AspNetCore.Mvc;
using HBStore.Interface.InterfaceService;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _IAddressService;

        public AddressController(IAddressService addressService)
        {
            _IAddressService = addressService;
        }

        [HttpGet]
        public async Task<List<Address>> GetAllAddress()
        {
            return await _IAddressService.GetAllAddress();
        }

        [HttpGet("getaddressbyid")]
        public async Task<Address> GetAddress([FromQuery] int id)
        {
            return await _IAddressService.GetAddress(id);
        }

        [HttpGet("getalldistrictscitybyid")]
        public async Task<List<District>> GetAllDistrictsCityById([FromQuery] int id)
        {
            return await _IAddressService.GetAllDistrictsByCityId(id);
        }

        [HttpPost]
        public async Task<Address> RegisterAddress(Address address)
        {
            return await _IAddressService.RegisterAddress(address);
        }

        [HttpDelete("deleteddress")]
        public async Task<Address> DeleteAddress([FromQuery] int id)
        {
            return await _IAddressService.DeleteAddress(id);
        }

        [HttpPut("updateaddress")]
        public async Task<Address> UpdateAddress([FromQuery] Address address)
        {
            var result = await _IAddressService.UpdateAddress(address);
            return result;
        }
           
        [HttpPost("createcity")]
        public async Task<City> CreateCity(City city)
        {
            return await _IAddressService.CreateCity(city);
        }

        [HttpPost("createdistrict")]
        public async Task<District> CreateDistrict(District district)
        {
            return await _IAddressService.CreateDistrict(district);
        }

        [HttpDelete("deletecity")]
        public async Task<City> DeleteCity(City city)
        {
            return await _IAddressService.DeleteCity(city);
        }

        [HttpDelete("deletedistrict")]
        public async Task<District> DeleteDistrict(District district)
        {
            return await _IAddressService.DeleteDistrict(district);
        }

    }
}