namespace HBStore.Repository
{
    public class AddressRepository : IAddressRepository
    {
        HBStoreDbContext _context;

        public AddressRepository()
        {
            _context = new HBStoreDbContext();
        }

        public async Task<Address> RegisterAddress(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddress(Address address)
        {
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var result = _context.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<List<Address>> GetAllAddress()
        {
            return await _context.Set<Address>().ToListAsync();
        }

        public async Task<Address> GetAddressById(int id)
        {
            var result = await _context.Set<Address>().SingleOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<City> CreateCity(City city)
        {
            await _context.Set<City>().AddAsync(city);
            await _context.SaveChangesAsync();
            return city;

        }
        public async Task<City> FindCityByName(string CityName)
        {
            return await _context.Set<City>().FirstOrDefaultAsync(x => x.Name == CityName);
        }

        public async Task<City> DeleteCity(City city)
        {
            _context.Set<City>().Remove(city);
            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<District> CreateDistrict(District district)
        {
            await _context.Set<District>().AddAsync(district);
            await _context.SaveChangesAsync();
            return district;
        }

        public async Task<District> FindDistrictByName(string DistrictName)
        {
            return await _context.Set<District>().FirstOrDefaultAsync(x => x.Name == DistrictName);
        }

        public async Task<List<District>> GetAllDistrictsByCityId(int id)
        {
            var result = await _context.Set<District>().Where(x => x.CityId == id).ToListAsync();
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<District> DeleteDistrict(District district)
        {
            _context.Set<District>().Remove(district);
            await _context.SaveChangesAsync();
            return district;
        }

    }
}