using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer, int id);
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetByCustomerId(int productId);
        Task <Customer> GetCustomerByName(string customerName);
        Task<List<Customer>> GetAllCustomerByOrderId(int orderId);

    }
}