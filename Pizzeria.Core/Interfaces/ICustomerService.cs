using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface ICustomerService
    {
        public bool SaveAll();
        Customer GetCustomerById(int id);
        Customer FirstOrDefault(Expression<Func<Customer, bool>> predicate);
        void AddCustomer(Customer entity);
        void UpdateCustomer(Customer entity);
        void RemoveCustomer(Customer entity);
        int CountAllCustomers();
        PagedList<Customer> GetAllCustomersPaged(CustomerParameters parameters);
    }
}