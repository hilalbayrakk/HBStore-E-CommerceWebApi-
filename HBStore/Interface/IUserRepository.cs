namespace HBStore.Interface
{
    public interface IUserRepository
    {
        Task <User> AddUser(User user);
        Task DeleteUser(User user);
        Task <User> UpdateUser(User user);
        Task <List<User>> GetAllUser();
        Task <User> GetUserById(int userId);
        Task <User>  GetUserByUserName(string userName);
        Task<User> GetUserByAccountId(int accountId);
        Task<List<User>> GetAllUserByGenderId(int genderId);

    }
}