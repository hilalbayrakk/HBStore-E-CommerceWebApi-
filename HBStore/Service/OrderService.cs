namespace HBStore.Service
{
    public class OrderService : ControllerBase, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> AddOrder(Order order)
        {
           var result = _orderRepository.GetOrderByName(order.Name);
           if(result == null)
           {
               return await _orderRepository.AddOrder(order);
           }
            throw new InvalidOperationException("Ayni isimde bir siparis bulunmaktadir!");
        }

        public async Task<Order> UpdateOrder(Order order, int id)
        {
            var result = await  _orderRepository.GetOrderById(id);
            if(result != null)
            {
                result = order;
                await _orderRepository.UpdateOrder(order);
                return order;
            }
             throw new InvalidOperationException("Guncellenecek siparis bulunamadi!");
        }

        public async Task DeleteOrder(Order order)
        {
            var result = _orderRepository.GetOrderById(order.Id);
            if(result != null)
            {
                await _orderRepository.DeleteOrder(order);
            }
             throw new InvalidOperationException("Silinecek siparis bulunamadi!");
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _orderRepository.GetAllOrder();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderRepository.GetOrderById(orderId);
        }

        public async Task<Order> GetOrderByName(string orderName)
        {
            return await _orderRepository.GetOrderByName(orderName);
        }

        public async Task<List<Order>> GetAllOrderByProductId(int productId)
        {
            return await _orderRepository.GetAllOrderByProductId(productId);
        }

        public async Task<List<Order>> GetAllOrderByCustomerId(int customerId)
        {
            return await _orderRepository.GetAllOrderByCustomerId(customerId);
        }

        public async Task<List<Order>> GetAllOrderByPaymentId(int paymentId)
        {
           return await _orderRepository.GetAllOrderByPaymentId(paymentId);
        }





    }
}