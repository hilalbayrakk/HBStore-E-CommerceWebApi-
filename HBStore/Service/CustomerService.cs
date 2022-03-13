using HBStore.Interface.InterfaceRepository;
using HBStore.Interface.InterfaceService;
using HBStore.Model;

namespace HBStore.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _customerRepository.GetCustomerByName(customer.Name);
            if(result != null)
            {
                return await _customerRepository.AddCustomer(customer);
            }
            throw new InvalidOperationException("Aynı isimde baska bir musteri bulunuyor!");
        }

        public async Task DeleteCustomer(Customer customer)
        {
            var result = _customerRepository.GetByCustomerId(customer.Id);
            if(result != null)
            {
                await _customerRepository.DeleteCustomer(customer);
            }
            throw new Exception("Silinecek musteri bulunamadi!");
        }

        public async Task<Customer> UpdateCustomer(Customer customer, int id)
        {
            var result = await _customerRepository.GetByCustomerId(id);
            if(result != null)
            {
                result = customer;
                await _customerRepository.UpdateCustomer(customer);
                return customer;
            }
            throw new InvalidOperationException("Guncellenecek musteri bulunamadi!");
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }

        public async Task<Customer> GetByCustomerId(int customerId)
        {
           return await _customerRepository.GetByCustomerId(customerId);
        }

        public async Task<Customer>GetCustomerByName(string customerName)
        {
            var result = _customerRepository.GetCustomerByName(customerName);
            if(result != null)
            {
                return await result;
            }
            throw new InvalidOperationException("Musteri bulunamadi!");
        }
        public async Task<List<Customer>> GetAllCustomerByOrderId(int orderId)
        {
            return await _customerRepository.GetAllCustomerByOrderId(orderId);
        }


    }
}