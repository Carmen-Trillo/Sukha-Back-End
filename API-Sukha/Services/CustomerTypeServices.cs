using API_Sukha.IServices;
using API_Sukha.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly ICustomerTypeLogic _customerTypeLogic;
        public CustomerTypeServices(ICustomerTypeLogic customerTypeLogic)
        {
            _customerTypeLogic = customerTypeLogic;
        }

        public void DeleteCustomerType(int id)
        {
            _customerTypeLogic.DeleteCustomerType(id);
        }

        public List<CustomerTypeItem> GetAllCustomerTypes()
        {
            return _customerTypeLogic.GetAllCustomerTypes();
        }

        public int InsertCustomerType(CustomerTypeItem customerTypeItem)
        {
            _customerTypeLogic.InsertCustomerType(customerTypeItem);
            return customerTypeItem.Id;
        }

        public void UpdateCustomerType(CustomerTypeItem customerTypeItem)
        {
            _customerTypeLogic.UpdateCustomerType(customerTypeItem);
        }

    }
}
