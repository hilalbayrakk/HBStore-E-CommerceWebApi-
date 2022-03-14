using HBStore.Context;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class AddressRepository : IAddressRepository
    {
        HBStoreDbContext _context;

        public AddressRepository()
        {
            _context = new HBStoreDbContext();
        }

        public async Task<City> CreateCity(City city)
        {
            await _context.Set<City>().AddAsync(city);
            await _context.SaveChangesAsync();
            return city;

        }

        public async Task<District> CreateDistrict(District district)
        {
            await _context.Set<District>().AddAsync(district);
            await _context.SaveChangesAsync();
            return district;
        }

        public async Task<Address> DeleteAddress(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> DeleteCity(City city)
        {
            _context.Set<City>().Remove(city);
            _context.SaveChangesAsync();
            return city;
        }

        public async Task<District> DeleteDistrict(District district)
        {
            _context.Set<District>().Remove(district);
            _context.SaveChangesAsync();
            return district;
        }

        public async Task<City> FindCityByName(string CityName)
        {
            return await _context.Set<City>().FirstOrDefaultAsync(c => c.Name == CityName);
        }

        public async Task<District> FindDistrictByName(string DistrictName)
        {
            return await _context.Set<District>().FirstOrDefaultAsync(c => c.Name == DistrictName);
        }

        public async Task<Address> GetAddress(int id)
        {
            var getAddress = await _context.Set<Address>().SingleOrDefaultAsync(p => p.Id == id);

            if (getAddress != null)
            {

                return getAddress;

            }
            else
            {
                return null;
            }
        }


        public async Task<List<Address>> GetAllAddress()
        {
            return await _context.Set<Address>().ToListAsync();
        }

        public async Task<List<District>> GetAllDistrictsByCityId(int id)
        {
            var Districts = await _context.Set<District>().Where(p => p.CityId == id).ToListAsync();
            if (Districts != null)
            {

                return Districts;

            }
            else
            {
                return null;
            }
        }
        public async Task<Address> RegisterAddress(Address address)
        {
            _context.Address.AddAsync(address);
            _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var result = _context.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }
    }
}