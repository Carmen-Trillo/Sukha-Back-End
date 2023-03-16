using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IUserServices
    {
        int InsertUser(NewUserRequest newUserRequest);
        void UpdateUser(UserItem userItem);
        void DeleteUser(int id);
        List<UserItem> GetAllUsers();
        List<UserItem> GetUsersByCriteria(UserFilter userFilter);
    }
}
