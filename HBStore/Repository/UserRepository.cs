using HBStore.Context;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HBStoreDbContext _context;

        public UserRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            var result = _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return result;
        }

        public async Task<User> GetUserByAccountId(int accountId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.AccountId == accountId);
        }

        public async Task<List<User>> GetAllUserByGenderId(int genderId)
        {
            return await _context.Users.Where(x => x.Id == genderId).ToListAsync();
        }



    }
}