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
    public class CustomerTypeLogic : ICustomerTypeLogic
    {
        private readonly ServiceContext _serviceContext;
        public CustomerTypeLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertCustomerType(CustomerTypeItem customerTypeItem)
        {
            _serviceContext.CustomerTypes.Add(customerTypeItem);
            _serviceContext.SaveChanges();
            return customerTypeItem.Id;
        }

        public void UpdateCustomerType(CustomerTypeItem customerTypeItem)
        {
            _serviceContext.CustomerTypes.Update(customerTypeItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteCustomerType(int id)
        {
            var customerTypeToDelete = _serviceContext.Set<CustomerTypeItem>()
                .Where(u => u.Id == id).First();

            customerTypeToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }


        public List<CustomerTypeItem> GetAllCustomerTypes()
        {
            return _serviceContext.Set<CustomerTypeItem>().ToList();
        }
    }
}
