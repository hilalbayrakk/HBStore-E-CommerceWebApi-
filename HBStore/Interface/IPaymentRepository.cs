namespace HBStore.Interface
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task DeletePayment(Payment payment);
        Task<List<Payment>> GetAllPayment();
        Task<Payment> GetPaymentByType(string paymentType);     
        Task<Payment> GetPaymentById(int paymentId);
        Task<List<Payment>> GetAllPaymentByCustomerId(int customerId);
        Task<List<Payment>> GetAllPaymentByCardId(int cardId);
    }
}