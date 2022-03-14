using HBStore.Context;
using HBStore.Interface.InterfaceRepository;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly HBStoreDbContext _context;

        public OrderRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
           await _context.AddAsync(order);
           await _context.SaveChangesAsync();
           return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
           var result = _context.Update(order);
           await _context.SaveChangesAsync();
           return order;
        }

        public async Task DeleteOrder(Order order)
        {
            var result = _context.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<Order> GetOrderByName(string orderName)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Name == orderName);
        }

        public async Task<List<Order>> GetAllOrderByProductId(int productId)
        {
            return await _context.Orders.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrderByCustomerId(int customerId)
        {
            return await _context.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrderByPaymentId(int paymentId)
        {
            return await _context.Orders.Where(x => x.PaymentId == paymentId).ToListAsync();

        }


    }
}