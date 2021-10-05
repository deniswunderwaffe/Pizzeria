using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.HelperClasses.Sorting;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ISortHelper<Order> _sortHelper;
        private readonly IPromotionalCodeService _promotionalCodeService;

        public OrderService(IOrderRepository repository, ISortHelper<Order> sortHelper, IPromotionalCodeService promotionalCodeService)
        {
            _repository = repository;
            _sortHelper = sortHelper;
            _promotionalCodeService = promotionalCodeService;
        }
        
        public bool SaveAll()
        {
            return _repository.SaveAll();
        }

        public Order GetOrderById(int id)
        {
            var order = _repository.GetOrderByIdIncludingAllDetails(id);
            return order;
        }

        public Order FirstOrDefault(Expression<Func<Order, bool>> predicate)
        {
            var order = _repository.FirstOrDefault(predicate);
            return order;
        }

        public void AddOrder(Order entity,string promotionalCodeToCheck)
        {
            var validatedCode =  _promotionalCodeService.ValidateCode(promotionalCodeToCheck);
            //TODO Как добавлять статус. Запоминать по айди или доставаь по имени
            entity.CustomerId = 1;
            entity.OrderStatusId = 1;
            
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

        public int CountAllOrders()
        {
            var count = _repository.CountAll();
            return count;
        }

        public PagedList<Order> GetAllOrdersPaged(OrderParameters parameters)
        {
            var orders = _repository.GetAllOrdersIncludingAllDetailsAsQueryable();
            orders = orders.Where(x => x.TotalPrice >= parameters.MinPrice && x.TotalPrice <=parameters.MaxPrice);
            
            var sortedOrders = _sortHelper.ApplySort(orders, parameters.OrderBy);
            return PagedList<Order>.ToPagedList(sortedOrders,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}