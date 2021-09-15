using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Pizzeria.Core.Exceptions;
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
            if (entity.OrderDrinks.Exists(x=>x.DrinkId == 0) ||
                entity.OrderPizzas.Exists(x=>x.PizzaId == 0))
            {
                throw new EmptyOrderCollectionBodyException(HttpStatusCode.BadRequest, "At least one order collection is empty");
            }
            _repository.Add(entity);
            SaveAll();
        }

        public void UpdateOrder(Order entity)
        {
            if (!entity.OrderDrinks.Any() || !entity.OrderPizzas.Any())
            {
                throw new EmptyOrderCollectionBodyException(HttpStatusCode.BadRequest, "Order body cannot be empty");
            }
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