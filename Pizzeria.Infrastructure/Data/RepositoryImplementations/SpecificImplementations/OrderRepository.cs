using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations
{
    public class OrderRepository:EfRepository<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<Order> GetPriorityOrders()
        {
            return _db.Orders.Where(x => x.Priority);
        }

        public IEnumerable<Order> GetAllOrdersIncludingAllDetails()
        {
            return _db.Orders
                .Include(x => x.Drinks)
                .Include(x => x.Pizzas)
                    .ThenInclude(x=>x.Ingredients)
                .AsSplitQuery()
                .AsNoTracking()
                .ToList();
        }

        public Order GetOrderByIdIncludingAllDetails(int id)
        {
            return _db.Orders
                .Include(x => x.Drinks)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.Ingredients)
                .AsSplitQuery()
                .FirstOrDefault(x => x.Id == id);

        }
    }
}