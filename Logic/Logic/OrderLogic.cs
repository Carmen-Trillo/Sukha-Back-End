using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ServiceContext _serviceContext;
        public OrderLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertOrder(OrderItem orderItem)
        {
            //get para comprobar que la cantida pedido<=sctok, añadir el pedido y despés hacer un update que modifique el stock
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
            return orderItem.Id;
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Update(orderItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var orderToDelete = _serviceContext.Set<OrderItem>()
                .Where(p => p.Id == id).First();

            orderToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<OrderItem> GetAllOrders()
        {
            return _serviceContext.Set<OrderItem>().ToList();
        }

        public List<OrderItem> GetOrdersByCriteria(OrderFilter orderFilter)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.IsActive == true);
                                            //.Where(p => p.Pagado == true)
                                            //.Where(p => p.Entregado == true);
                                            
            //.Where(p => p.Pagado == true);




            if (orderFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(p => p.FechaPedido > orderFilter.InsertDateFrom);
            }

            if (orderFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(p => p.FechaPedido < orderFilter.InsertDateTo);
            }
            if (orderFilter.ImporteTotalDesde != null)
            {
                resultList = resultList.Where(p => p.ImporteTotal > orderFilter.ImporteTotalDesde);
            }

            if (orderFilter.ImporteTotalHasta != null)
            {
                resultList = resultList.Where(p => p.ImporteTotal < orderFilter.ImporteTotalHasta);
            }

            if (orderFilter.FechaEntregaDesde != null)
            {
                resultList = resultList.Where(p => p.FechaEntrega > orderFilter.FechaEntregaDesde);
            }

            if (orderFilter.FechaEntregaHasta != null)
            {
                resultList = resultList.Where(p => p.FechaEntrega < orderFilter.FechaEntregaHasta);
            }

            return resultList.ToList();

        }

        private void Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetOrdersByCustomer(int idCustomer)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                        .Where(p => p.IdCustomer == idCustomer);
            return resultList.ToList();
        }

        public List<OrderItem> GetOrdersByProduct(int idProduct)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                        .Where(p => p.IdProduct == idProduct);
            return resultList.ToList();
        }

        public List<OrderItem> GetOrdersByPagados(bool pagado)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Pagado == true);
            var resultListNoPagados = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Pagado == false);

            if (pagado == true)
            {
                return resultList.ToList();
            }
            else
            {
                return resultListNoPagados.ToList();
            }
        }
        public List<OrderItem> GetOrdersByEntregados(bool entregado)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Entregado == true);
            var resultListNoEntregados = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Entregado == false);

            if (entregado == true)
            {
                return resultList.ToList();
            }
            else
            {
                return resultListNoEntregados.ToList();
            }
        }
    }
}