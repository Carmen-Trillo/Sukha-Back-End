using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface ICustomerServices
    {
        int InsertCustomer(CustomerItem customerItem);
        void UpdateCustomer(CustomerItem customerItem);
        void DeleteCustomer(int id);
        List<CustomerItem> GetAllCustomers();
        List<CustomerItem> GetCustomersByCriteria(CustomerFilter customerFilter);
    }
}
