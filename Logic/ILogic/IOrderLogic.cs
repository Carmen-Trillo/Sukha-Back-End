using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IOrderLogic
    {
        int InsertOrder(OrderItem orderItem);
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
