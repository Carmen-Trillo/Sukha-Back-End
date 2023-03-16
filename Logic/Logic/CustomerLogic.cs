using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ServiceContext _serviceContext;
        public CustomerLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertCustomer(CustomerItem customerItem)
        {
            if (customerItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            _serviceContext.Customers.Add(customerItem);
            _serviceContext.SaveChanges();
            return customerItem.Id;
        }

        public void UpdateCustomer(CustomerItem customerItem)
        {
            _serviceContext.Customers.Update(customerItem);

            _serviceContext.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customerToDelete = _serviceContext.Set<CustomerItem>()
                 .Where(u => u.Id == id).First();

            customerToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<CustomerItem> GetAllCustomers()
        {
            return _serviceContext.Set<CustomerItem>().ToList();
        }
        public List<CustomerItem> GetCustomersByCriteria(CustomerFilter customerFilter)
        {
            var resultList = _serviceContext.Set<CustomerItem>()
                                .Where(u => u.IsActive == true);

            if (customerFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > customerFilter.InsertDateFrom);
            }

            if (customerFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < customerFilter.InsertDateTo);
            }

            return resultList.ToList();
        }
    }
}
