using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICustomerLogic
    {
        int InsertCustomer(CustomerItem customerItem);
        void UpdateCustomer(CustomerItem customerItem);
        void DeleteCustomer(int id);
        List<CustomerItem> GetAllCustomers();
        List<CustomerItem> GetCustomersByCriteria(CustomerFilter customerFilter);
    }
}
