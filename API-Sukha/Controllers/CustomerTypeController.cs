using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerTypeController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private ICustomerTypeServices _customerTypeServices;
        public CustomerTypeController(ISecurityServices securityServices, ICustomerTypeServices customerTypeServices)
        {
            _securityServices = securityServices;
            _customerTypeServices = customerTypeServices;
        }

        [HttpPost(Name = "InsertarTipoCliente")]
        public int Post([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] CustomerTypeItem customerTypeItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _customerTypeServices.InsertCustomerType(customerTypeItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerTipoCliente")]
        public List<CustomerTypeItem> GetAllCustomerTypes([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _customerTypeServices.GetAllCustomerTypes();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarTipoCliente")]
        public void Patch([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] CustomerTypeItem customerTypeItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _customerTypeServices.UpdateCustomerType(customerTypeItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarTipoCliente")]
        public void Delete([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _customerTypeServices.DeleteCustomerType(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
