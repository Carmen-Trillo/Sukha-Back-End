using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    //ServiceContext _serviceContext;
    public class NewOrderRequest
    {
        //public NewPedidoRequest(ServiceContext serviceContext) {
        //    _serviceContext = serviceContext;
        //}
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCustomer { get; set; }
        public int IdCustomerType { get; set; }

        public int IdProduct { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public decimal Descuento { get; private set; }
        public decimal ImporteTotal { get; private set; }

        public DateTime FechaEntrega { get; set; }
        public bool Pagado { get; set; }
        public bool Entregado { get; set; }
        public bool IsActive { get; set; }

        public OrderItem ToOrderItem()
        {
            var orderItem = new OrderItem();

            orderItem.IdWeb = IdWeb;
            orderItem.FechaPedido = FechaPedido;
            orderItem.IdProduct = IdProduct;
            orderItem.IdCustomer = IdCustomer;
            orderItem.IdCustomerType= IdCustomerType;
            orderItem.Cantidad = Cantidad;
            orderItem.Precio= Precio;

            //pedidoItem.Descuento = 0.2M * (Cantidad * Precio);

            if (orderItem.IdCustomerType == 1)
            {
                orderItem.Descuento = 0.1M* (Cantidad * Precio);
            }
            else if (orderItem.IdCustomerType == 2)
            {
                orderItem.Descuento = 0.15M* (Cantidad * Precio);
            }
            else if (orderItem.IdCustomerType == 3)
            {
                orderItem.Descuento = 0.2M * (Cantidad * Precio);
            }
            else
            {
                orderItem.Descuento = 0;
            }

            if (orderItem.IdCustomerType == 1)
            {
                orderItem.ImporteTotal = 0.9M * (Cantidad * Precio);
            }
            else if (orderItem.IdCustomerType == 2)
            {
                orderItem.ImporteTotal = 0.85M * (Cantidad * Precio);
            }
            else if (orderItem.IdCustomerType == 3)
            {
                orderItem.ImporteTotal = 0.8M * (Cantidad * Precio);
            }
            else
            {
                orderItem.ImporteTotal = Cantidad*Precio;
            }
            //pedidoItem.ImporteTotal = (Cantidad * Precio) - pedidoItem.Descuento;
 
            orderItem.FechaEntrega = FechaEntrega;
            orderItem.Pagado = Pagado;
            orderItem.Entregado = Entregado;
            orderItem.IsActive = true;

            return orderItem;

            //buscas en base el producto y su precio.
        }
    }
}
