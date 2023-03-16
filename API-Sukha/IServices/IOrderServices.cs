using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IOrderServices
    {
        int InsertOrder(NewOrderRequest newOrderRequest);
        void UpdateOrder(OrderItem orderItem);
        void DeleteOrder(int id);
        List<OrderItem> GetAllOrders();
        List<OrderItem> GetOrdersByCriteria(OrderFilter orderFilter);
        List<OrderItem> GetOrdersByCustomer(int idCustomer);
        List<OrderItem> GetOrdersByProduct(int idProduct);
        List<OrderItem> GetOrdersByPagados(bool pagado);
        List<OrderItem> GetOrdersByEntregados(bool entregado);
    }
}