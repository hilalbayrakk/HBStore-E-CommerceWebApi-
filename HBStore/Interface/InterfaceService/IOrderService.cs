using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order, int id);
        Task DeleteOrder(Order order);
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(int orderId);
        Task<Order> GetOrderByName(string orderName);
        Task<List<Order>> GetAllOrderByProductId(int productId);
        Task<List<Order>> GetAllOrderByCustomerId(int customerId);
        Task<List<Order>> GetAllOrderByPaymentId(int paymentId);

    }
}