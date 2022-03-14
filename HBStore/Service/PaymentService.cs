using HBStore.Interface;
using HBStore.Model;

namespace HBStore.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            var result = await _paymentRepository.GetPaymentByType(payment.Type);
            if (result == null)
            {
                return await _paymentRepository.AddPayment(payment);
            }
            throw new InvalidOperationException("Aynı tipte bir odeme bulunmaktadir!");
        }

        public async Task<Payment> UpdatePayment(Payment payment, int id)
        {

            var result = await _paymentRepository.GetPaymentById(id);
            if (result != null)
            {
                result = payment;
                await _paymentRepository.UpdatePayment(payment);
                return payment;
            }
            throw new InvalidOperationException("Guncellenecek odeme bulunamadi!");
        }

        public async Task DeletePayment(Payment payment)
        {
            var result = _paymentRepository.GetPaymentById(payment.Id);
            if(result != null)
            {
                await _paymentRepository.DeletePayment(payment);
            }
            throw new Exception("Silinecek odeme bulunamadi!");
        }

        public async Task<List<Payment>> GetAllPayment()
        {
            return await _paymentRepository.GetAllPayment();
        }

        public async Task<Payment> GetPaymentByType(string paymentType)
        {
            return await _paymentRepository.GetPaymentByType(paymentType);
        }
        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await _paymentRepository.GetPaymentById(paymentId);
        }

        public async Task<List<Payment>> GetAllPaymentByCustomerId(int customerId)
        {
            return await _paymentRepository.GetAllPaymentByCustomerId(customerId);
        }

        public async Task<List<Payment>> GetAllPaymentByCardId(int cardId)
        {
            return await _paymentRepository.GetAllPaymentByCardId(cardId);
        }


    }
}