using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class SecurityLogic : ISecurityLogic
    {
        private readonly ServiceContext _serviceContext;
        public SecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public bool ValidateUserCredentials(string userUsuario, string userPassWord, int idRolItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                                .Where(u => u.Usuario == userUsuario
                                    && u.Password == userPassWord
                                    && u.IdRol == idRolItem).FirstOrDefault();

            if (selectedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
