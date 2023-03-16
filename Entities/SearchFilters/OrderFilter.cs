using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SearchFilters
{
    public class OrderFilter
    {
        public bool IsActive { get; set; }
        public DateTime? InsertDateFrom { get; set; }
        public DateTime? InsertDateTo { get; set; }
        public int? ImporteTotalDesde { get; set; }
        public int? ImporteTotalHasta { get; set; }
        //public int? IdCliente { get; set;  }
        //public int?  IdProducto { get;set; }
        public DateTime? FechaEntregaDesde { get; set; }
        public DateTime? FechaEntregaHasta { get; set; }
        //public bool Pagado { get; set; }
        //public bool Entregado { get; set; }
    }
}
