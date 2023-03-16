using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;

namespace API_Sukha.Services
{
    public class RolServices : IRolServices
    {
        private readonly IRolLogic _rolLogic;
        public RolServices(IRolLogic rolLogic)
        {
            _rolLogic = rolLogic;
        }

        public void DeleteRol(int id)
        {
            _rolLogic.DeleteRol(id);
        }

        public List<RolItem> GetAllRoles()
        {
            return _rolLogic.GetAllRoles();
        }

        public int InsertRol(RolItem rolItem)
        {
            _rolLogic.InsertRol(rolItem);
            return rolItem.Id;
        }

        public void UpdateRol(RolItem rolItem)
        {
            _rolLogic.UpdateRol(rolItem);
        }
    }
}
