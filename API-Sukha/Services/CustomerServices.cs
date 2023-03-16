using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerLogic _customerLogic;
        public CustomerServices(ICustomerLogic customerLogic)
        {
            _customerLogic = customerLogic;
        }
        public int InsertCustomer(CustomerItem customerItem)
        {
            _customerLogic.InsertCustomer(customerItem);
            return customerItem.Id;
        }
        public List<CustomerItem> GetAllCustomers()
        {
            return _customerLogic.GetAllCustomers();
        }
        public List<CustomerItem> GetCustomersByCriteria(CustomerFilter customerFilter)
        {
            return _customerLogic.GetCustomersByCriteria(customerFilter);
        }

        public void UpdateCustomer(CustomerItem customerItem)
        {
            _customerLogic.UpdateCustomer(customerItem);
        }

        public void DeleteCustomer(int id)
        {
            _customerLogic.DeleteCustomer(id);
        }
    }
}