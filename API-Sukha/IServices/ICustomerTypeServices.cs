using Entities.Entities;

namespace API_Sukha.IServices
{
    public interface ICustomerTypeServices
    {
        int InsertCustomerType(CustomerTypeItem customerTypeItem);
        void UpdateCustomerType(CustomerTypeItem customerTypeItem);
        void DeleteCustomerType(int id);
        List<CustomerTypeItem> GetAllCustomerTypes();
    }
}
