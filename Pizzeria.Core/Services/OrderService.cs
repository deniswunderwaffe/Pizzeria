using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public bool SaveAll()
        {
            return  _repository.SaveAll();
        }

        public Order GetOrderById(int id)
        {
            return _repository.GetById(id);
        }

        public Order FirstOrDefault(Expression<Func<Order, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public void AddOrder(Order entity)
        {
            _repository.Add(entity);
            SaveAll();
        }

        public void UpdateOrder(Order entity)
        {
            _repository.Update(entity);
            SaveAll();
        }

        public void RemoveOrder(Order entity)
        {
            _repository.Remove(entity);
            SaveAll();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public int CountAllOrders()
        {
            return _repository.CountAll();
        }

        public IEnumerable<Order> GetPriorityOrders()
        {
            return _repository.GetPriorityOrders();
        }

        public Order GetOrderByIdIncludingAllDetails(int id)
        {
            return _repository.GetOrderByIdIncludingAllDetails(id);
        }

        public IEnumerable<Order> GetAllOrdersIncludingAllDetails()
        {
            return _repository.GetAllOrdersIncludingAllDetails();
        }
    }
}