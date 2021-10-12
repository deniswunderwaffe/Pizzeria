using System;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public bool SaveAll()
        {
            return _repository.SaveAll();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _repository.GetById(id);
            return customer;
        }

        public Customer GetCustomerByPhone(string phone)
        {
            var customer = _repository.FirstOrDefault(x => x.Phone == phone);
            return customer;
        }

        public Customer FirstOrDefault(Expression<Func<Customer, bool>> predicate)
        {
            var customer = _repository.FirstOrDefault(predicate);
            return customer;
        }

        public void AddCustomer(Customer entity)
        {
            _repository.Add(entity);
            SaveAll();
        }

        public void UpdateCustomer(Customer entity)
        {
            _repository.Update(entity);
            SaveAll();
        }

        public void RemoveCustomer(Customer entity)
        {
            _repository.Remove(entity);
            SaveAll();
        }

        public int CountAllCustomers()
        {
            var count = _repository.CountAll();
            return count;
        }

        public PagedList<Customer> GetAllCustomersPaged(CustomerParameters parameters)
        {
            var customers = _repository.GetAllQueryable();
            return PagedList<Customer>.ToPagedList(customers,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}