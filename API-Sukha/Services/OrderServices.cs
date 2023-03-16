using API_Sukha.IServices;
using API_Sukha.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderLogic _orderLogic;
        public OrderServices(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public void DeleteOrder(int id)
        {
            _orderLogic.DeleteOrder(id);
        }

        public List<OrderItem> GetAllOrders()
        {
            return _orderLogic.GetAllOrders();
        }

        public List<OrderItem> GetOrdersByCriteria(OrderFilter orderFilter)
        {
            return _orderLogic.GetOrdersByCriteria(orderFilter);
        }

        public List<OrderItem> GetOrdersByCustomer(int idCustomer)
        {
            return _orderLogic.GetOrdersByCustomer(idCustomer);
        }

        public List<OrderItem> GetOrdersByProduct(int idProduct)
        {
            return _orderLogic.GetOrdersByProduct(idProduct);
        }
        public List<OrderItem> GetOrdersByPagados(bool pagado)
        {
            return _orderLogic.GetOrdersByPagados(pagado);
        }
        public List<OrderItem> GetOrdersByEntregados(bool entregado)
        {
            return _orderLogic.GetOrdersByEntregados(entregado);
        }


        public int InsertOrder(NewOrderRequest newOrderRequest)
        {

            var newOrderItem = newOrderRequest.ToOrderItem();
            return _orderLogic.InsertOrder(newOrderItem);
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _orderLogic.UpdateOrder(orderItem);
        }
    }
}

