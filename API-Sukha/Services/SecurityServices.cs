using API_Sukha.IServices;
using Data;
using Entities.Entities;
using Logic.ILogic;

namespace API_Sukha.Services
{
    public class SecurityServices : ISecurityServices
    {
        private readonly ISecurityLogic _securityLogic;

        public SecurityServices(ISecurityLogic securityLogic)
        {
            _securityLogic = securityLogic;
        }
        public bool ValidateUserCredentials(string userUsuario, string userPassWord, int idRol)
        {

            return _securityLogic.ValidateUserCredentials(userUsuario, userPassWord, idRol);
        }
    }
}
