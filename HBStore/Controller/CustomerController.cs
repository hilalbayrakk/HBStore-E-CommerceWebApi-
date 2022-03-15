using HBStore.Model;
using HBStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;


        public CustomerController(ICustomerService customerService)
        {
            _customerService = _customerService;
        }

        [HttpPost("add")]
        public async Task<Customer> Add(Customer customer)
        {
            await _customerService.AddCustomer(customer);
            return customer;
        }

        [HttpPut("update")]
        public async Task<Customer> Update([FromQuery] Customer customer, int id)
        {
            return await _customerService.UpdateCustomer(customer, id);
        }

        [HttpDelete]
        public async Task Delete(Customer customer)
        {
            await _customerService.DeleteCustomer(customer);
        }

        [HttpGet("getall")]
        public async Task<List<Customer>> GetAll()
        {
            return await _customerService.GetAllCustomer();
        }

        [HttpGet("getbyid")]
        public async Task<Customer> GetCustomerById([FromQuery] int customerId)
        {
            return await _customerService.GetCustomerById(customerId);
        }

        [HttpGet("getbyname")]
        public async Task<Customer> GetCustomerByName([FromQuery] string customerName)
        {
            return await _customerService.GetCustomerByName(customerName);
        }

        [HttpGet("getallbyorderid")]
        public async Task<List<Customer>> GetAllCustomerByOrderId(int orderId)
        {
            return await _customerService.GetAllCustomerByOrderId(orderId);
        }
    }
}
