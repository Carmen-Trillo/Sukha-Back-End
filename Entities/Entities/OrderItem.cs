using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCustomer { get; set; }
        public int IdCustomerType { get; set; }

        public int IdProduct { get; set; }
        public decimal Precio { get; set; }
        
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal ImporteTotal { get; set; }

        public DateTime FechaEntrega { get; set; }
        public bool Pagado { get; set; }
        public bool Entregado { get; set; }
        public bool IsActive { get; set; }
    }
}
