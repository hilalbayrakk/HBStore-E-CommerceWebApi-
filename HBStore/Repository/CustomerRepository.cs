using HBStore.Context;
using HBStore.Interface.InterfaceRepository;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HBStoreDbContext _context;

        public CustomerRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            var result = _context.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByCustomerId(int customerId)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.Id == customerId);
        }

        public async Task<Customer> GetCustomerByName(string customerName)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Name == customerName);
        }
        public async Task<List<Customer>> GetAllCustomerByOrderId(int orderId)
        {
            return await _context.Customers.Where(x => x.OrderId == orderId).ToListAsync();
        }


    }
}