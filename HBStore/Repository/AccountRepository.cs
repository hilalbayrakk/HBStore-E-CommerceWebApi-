using HBStore.Context;
using HBStore.Interface.InterfaceRepository;

namespace HBStore.Repository
{
    public class AccountRepository : IAccountRepository
    {      
        private readonly HBStoreDbContext _context;
    public AccountRepository(HBStoreDbContext context)
    {
        _context=context;
    }  
    }
}