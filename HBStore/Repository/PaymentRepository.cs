using HBStore.Context;
using HBStore.Interface.InterfaceRepository;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly HBStoreDbContext _context;

        public PaymentRepository (HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            var result = _context.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task DeletePayment(Payment payment)
        {
            var result = _context.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAllPayment()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentByType(string paymentType)
        {
            return await _context.Payments.SingleOrDefaultAsync(x => x.Type == paymentType);
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await _context.Payments.SingleOrDefaultAsync(x => x.Id == paymentId);
        }

        public async Task<List<Payment>> GetAllPaymentByCardId(int cardId)
        {
            return await _context.Payments.Where(x => x.CardId == cardId).ToListAsync();
        }

        public async Task<List<Payment>> GetAllPaymentByCustomerId(int customerId)
        {
            return await _context.Payments.Where(x => x.CustomerId == customerId).ToListAsync();
        }

      
    }
}