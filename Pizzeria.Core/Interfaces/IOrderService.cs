using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface IOrderService
    {
        public bool SaveAll();
        Order GetOrderById(int id);
        Order FirstOrDefault(Expression<Func<Order, bool>> predicate);
        void AddOrder(Order entity); //TODO УБАРТЬ
        void UpdateOrder(Order entity);
        void RemoveOrder(Order entity);
        int CountAllOrders();
        PagedList<Order> GetAllOrdersPaged(OrderParameters parameters);
    }
}