using HBStore.Model;
using HBStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public async Task<Order> Add(Order order)
        {
            await _orderService.AddOrder(order);
            return order;
        }
        
        [HttpPut("delete")]
        public async Task Delete(Order order)
        {
            await _orderService.DeleteOrder(order);
        }

        [HttpPut("update")]
        public async Task<Order> Update(Order order, int id)
        {
            var result = await _orderService.UpdateOrder(order, id);
            return order;
        }

        [HttpGet("getall")]
        public async Task<List<Order>> GetAll()
        {
            return await _orderService.GetAllOrder();
        }

        [HttpGet("getorderbyid")]
        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderService.GetOrderById(orderId);
        }

        [HttpGet("getorderbyname")]
        public async Task<Order> GetOrderByName(string orderName)
        {
            return await _orderService.GetOrderByName(orderName);
        }

        [HttpGet("getorderbyproductid")]
        public async Task<List<Order>> GetAllOrderByProductId(int productId)
        {
            return await _orderService.GetAllOrderByProductId(productId);
        }

        [HttpGet("getorderbycustomerid")]
        public async Task<List<Order>> GetAllOrderByCustomerId(int customerId)
        {
            return await _orderService.GetAllOrderByCustomerId(customerId);
        }


        [HttpGet("getorderbypaymentid")]
        public async Task<List<Order>> GetAllOrderByPaymentId(int paymentId)
        {
            return await _orderService.GetAllOrderByPaymentId(paymentId);
        }

    }

}