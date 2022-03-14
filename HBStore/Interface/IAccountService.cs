using HBStore.Model;

namespace HBStore.Interface
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountByEmail(string email);
        Task<Account> CreateNewAccount(Account account); 
        Task<Account> ChangeVisibilityOfAccount();
        Task<Account> UpdateAccountByEmail(Account account, string email);
        Task<Account> UpdateAccountPassword(Account account, string oldpassword, string newpassword);
        Task<Account> BlockAccount();
        Task<Account> Role();

    }
}