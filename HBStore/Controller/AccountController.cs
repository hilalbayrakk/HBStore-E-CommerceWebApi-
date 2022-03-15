using HBStore.Model;
using Microsoft.AspNetCore.Mvc;
using HBStore.Interface;
using HBStore.DTO;

namespace HBStore.Controller
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        public async Task<Account> CreateNewAccount(AccountDTO account)
        {
            Account accountresult = new Account()
            {
                Email = account.Email,
                Password = account.Password,
                IsBlocked = account.IsBlocked,
                Visibility = account.Visibility
            };
            return await _accountService.CreateNewAccount(accountresult);
        }

        [HttpPut("update")]
        public async Task<Account> UpdateAccountByEmail(Account account, string email)
        {
            var result = await _accountService.UpdateAccountByEmail(account, email);
            return result;
        }

        [HttpGet("getall")]
        public async Task<List<Account>> GetAll()
        {
            var allAccounts = await _accountService.GetAllAccounts();
            return allAccounts;
        }
        
        [HttpGet("getbyemail")]
        public async Task<Account> GetByAccountEmail(string email)
        {
            var result = await _accountService.GetAccountByEmail(email);
            return result;
        }
    }

}