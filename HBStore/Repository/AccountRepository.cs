namespace HBStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HBStoreDbContext _context;
        public AccountRepository(HBStoreDbContext context)
        {
            _context = context;
        }
        public AccountRepository()
        {

        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Set<Account>().ToListAsync();
        }

        public async Task<Account> CreateAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            return await _context.Set<Account>().SingleOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Account> UpdateAccountByEmail( Account account, string email)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountPassword(Account account, string oldpassword, string newpassword)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> ChangeVisibilityOfAccount()
        {
            throw new NotImplementedException();
        }

        public async Task<Account> BlockAccount()
        {
            throw new NotImplementedException();
        }

        public async Task<Account> Role()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDTO> CreateAccount(AccountDTO account)
        {
            try
            {
                Account persistAccount = new Account(account);

                _context.Set<Account>().AddAsync(persistAccount);
                _context.SaveChangesAsync();
                return new AccountDTO(persistAccount);
            }
            catch (Exception e)
            {
                return new AccountDTO(null);
            }
        }

        public async Task<Account> FindAccountByEmailAndPasswordAsync(LoginDTO loginDTO)
        {
            Account accountFinded = (from x in _context.Accounts
                                     where x.Email == loginDTO.Email && x.Password == loginDTO.Password
                                     select x).FirstOrDefault();
            return accountFinded;
        }
        public Account FindAccountByEmailAndPassword(LoginDTO loginDTO)
        {
            Account accountFinded = (from x in _context.Accounts
                                     where x.Email == loginDTO.Email && x.Password == loginDTO.Password
                                     select x).FirstOrDefault();
            return accountFinded;
        }

        public Account findAccountById(int id)
        {
            Account accountByID = (from x in _context.Accounts
                                   where x.Id == id
                                   select x).FirstOrDefault();
            return accountByID;
        }
        public async Task<Account> findAccountByIdAsync(int id)
        {
            Account accountByID = (from x in _context.Accounts
                                   where x.Id == id
                                   select x).FirstOrDefault();
            return accountByID;
        }
    }



}
