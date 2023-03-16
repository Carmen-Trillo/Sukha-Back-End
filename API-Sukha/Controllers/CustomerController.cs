using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using API_Sukha.IServices;
using System.Security.Authentication;
using Entities.SearchFilters;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private ICustomerServices _customerServices;
        public CustomerController(ISecurityServices securityServices, ICustomerServices customerServices)
        {
            _securityServices = securityServices;
            _customerServices = customerServices;
        }

        [HttpPost(Name = "InsertarClientes")]
        public int Post([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] CustomerItem customerItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _customerServices.InsertCustomer(customerItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerClientes")]
        public List<CustomerItem> GetAllCustomers([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _customerServices.GetAllCustomers();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarClientePorFiltro")]
        public List<CustomerItem> GetCustomersByCriteria([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] CustomerFilter customerFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _customerServices.GetCustomersByCriteria(customerFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


        [HttpPatch(Name = "ModificarCliente")]
        public void Patch([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] CustomerItem customerItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _customerServices.UpdateCustomer(customerItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


        [HttpDelete(Name = "EliminarCliente")]
        public void Delete([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _customerServices.DeleteCustomer(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
