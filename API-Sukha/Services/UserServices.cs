using API_Sukha.IServices;
using API_Sukha.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserLogic _userLogic;
        public UserServices(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public int InsertUser(NewUserRequest newUserRequest)
        {
            var newUserItem = newUserRequest.ToUserItem();
            return _userLogic.InsertUser(newUserItem);
        }
        public List<UserItem> GetAllUsers()
        {
            return _userLogic.GetAllUsers();
        }
        public List<UserItem> GetUsersByCriteria(UserFilter userFilter)
        {
            return _userLogic.GetUsersByCriteria(userFilter);
        }

        public void UpdateUser(UserItem userItem)
        {
            _userLogic.UpdateUser(userItem);
        }

        public void DeleteUser(int id)
        {
            _userLogic.DeleteUser(id);
        }
    }
}
