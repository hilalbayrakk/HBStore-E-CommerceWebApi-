using HBStore.Context;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly HBStoreDbContext _context;

        public GenderRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Gender> AddGender(Gender gender)
        {
            await _context.AddAsync(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task DeleteGender(Gender gender)
        {
            var result = _context.Remove(gender);
            await _context.SaveChangesAsync();
        }

        public async Task<Gender> UpdateGender(Gender gender)
        {
            var result = _context.Update(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task<List<Gender>> GetAllGender()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> GetGenderById(int genderId)
        {
            return await _context.Genders.SingleOrDefaultAsync(x => x.Id == genderId);
        }

        public async Task<List<Gender>> GetGenderByName(string genderName)
        {
            return await _context.Genders.Where(x => x.Name == genderName).ToListAsync();
        }

        public async Task<List<Gender>> GetGenderByUserId(int userId)
        {
            return await _context.Genders.Where(x => x.UserId == userId).ToListAsync();
        }

    }
}