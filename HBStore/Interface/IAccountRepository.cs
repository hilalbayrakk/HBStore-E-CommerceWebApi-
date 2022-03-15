using HBStore.DTO;
using HBStore.Model;

namespace HBStore.Interface
{
    public interface IAccountRepository
    {
   
    Task<List<Account>> GetAllAccounts();
    Task<Account> CreateAccount(Account account);
    Task<Account> GetAccountByEmail(string email);
    Task<Account> UpdateAccountByEmail(Account account, string email);
    Task<Account> UpdateAccountPassword(Account account,string oldpassword, string newpassword); 
    Task<Account> ChangeVisibilityOfAccount();
    Task<Account> BlockAccount();
    Task<Account> Role();
    Task<AccountDTO> CreateAccount(AccountDTO account);   
    Task<Account> FindAccountByEmailAndPasswordAsync(LoginDTO loginDTO);       
    Account FindAccountByEmailAndPassword(LoginDTO loginDTO); 
    
    Task<Account> findAccountByIdAsync(int id);
    Account findAccountById(int id);
}
}