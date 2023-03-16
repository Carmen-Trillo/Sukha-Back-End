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
    public class UserController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IUserServices _userServices;
        public UserController(ISecurityServices securityServices, IUserServices userServices)
        {
            _securityServices = securityServices;
            _userServices = userServices;
        }

        [HttpPost(Name = "InsertarUsuarios")]
        public int Post([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] NewUserRequest newUserRequest)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _userServices.InsertUser(newUserRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerUsuarios")]
        public List<UserItem> GetAllUsers([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _userServices.GetAllUsers();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarUsuarioPorFiltro")]
        public List<UserItem> GetUsersByCriteria([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] UserFilter userFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _userServices.GetUsersByCriteria(userFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarUsuario")]
        public void Patch([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] UserItem userItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _userServices.UpdateUser(userItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


        [HttpDelete(Name = "EliminarUsuario")]
        public void Delete([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _userServices.DeleteUser(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
