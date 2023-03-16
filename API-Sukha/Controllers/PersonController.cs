using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IPersonServices _personServices;
        public PersonController(ISecurityServices securityServices, IPersonServices personServices)
        {
            _securityServices = securityServices;
            _personServices = personServices;
        }

        [HttpPost(Name = "InsertarPersona")]
        public int Post([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] PersonItem personItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _personServices.InsertPerson(personItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerPersonas")]
        public List<PersonItem> GetAllPersons([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _personServices.GetAllPersons();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarPersona")]
        public void Patch([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] PersonItem personItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _personServices.UpdatePerson(personItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarPersona")]
        public void Delete([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _personServices.DeletePerson(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        /*[HttpGet(Name = "MostrarPersonaPorFiltro")]
        public List<PersonaItem> GetByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] PersonaFilter personaFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.GetPersonasByCriteria(personaFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }*/
    }
}
