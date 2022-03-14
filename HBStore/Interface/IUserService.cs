using HBStore.Model;

namespace HBStore.Interface
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task DeleteUser(User user);
        Task<User> UpdateUser(User user,int id);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int userId);
        Task<User> GetUserByUserName(string userName);
        Task<User> GetUserByAccountId(int accountId);
        Task<List<User>> GetAllUserByGenderId(int genderId);

    }
}