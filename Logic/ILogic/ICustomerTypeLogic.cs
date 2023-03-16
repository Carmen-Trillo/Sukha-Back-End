using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICustomerTypeLogic
    {
        int InsertCustomerType(CustomerTypeItem customerTypeItem);
        void UpdateCustomerType(CustomerTypeItem customerTypeItem);
        void DeleteCustomerType(int id);
        List<CustomerTypeItem> GetAllCustomerTypes();
    }
}
