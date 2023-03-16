using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IOrderServices _orderServices;
        public OrderController(ISecurityServices securityServices, IOrderServices orderServices)
        {
            _securityServices = securityServices;
            _orderServices = orderServices;
        }

        [HttpPost(Name = "InsertarPedido")]
        public int Post([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] NewOrderRequest newOrderRequest)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.InsertOrder(newOrderRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerPedidos")]
        public List<OrderItem> GetAllOrders([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.GetAllOrders();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorFiltro")]
        public List<OrderItem> GetOrdersByCriteria([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] OrderFilter orderFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.GetOrdersByCriteria(orderFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorCliente")]
        public List<OrderItem> GetOrdersByCliente([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int idCustomer)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.GetOrdersByCustomer(idCustomer);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorProductos")]
        public List<OrderItem> GetOrdersByProducto([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int idProduct)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.GetOrdersByProduct(idProduct);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorProductosPagados")]
        public List<OrderItem> GetOrdersByPagados([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] bool pagado)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.GetOrdersByPagados(pagado);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorProductosEntregados")]
        public List<OrderItem> GetOrdersByEntregados([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] bool entregado)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _orderServices.GetOrdersByEntregados(entregado);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarPedido")]
        public void Patch([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] OrderItem orderItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _orderServices.UpdateOrder(orderItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarPedido")]
        public void Delete([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _orderServices.DeleteOrder(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


    }
}
