using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
        }

        public Order GetOrderByIdIncludingAllDetails(int id)
        {
            var order = _db.Orders.AsNoTracking()
                .OrderAllIncludes()
                .FirstOrDefault(x => x.Id == id);

            return order;
        }

        public IQueryable<Order> GetAllOrdersIncludingAllDetailsAsQueryable()
        {
            var orders = _db.Orders.AsNoTracking()
                .OrderAllIncludes()
                .AsQueryable();
            
            return orders;
        }
    }
}