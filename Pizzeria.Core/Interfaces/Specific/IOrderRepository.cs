using System.Collections.Generic;
using System.Linq;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces.Specific
{
    public interface IOrderRepository:IRepository<Order>
    {
        Order GetOrderByIdIncludingAllDetails(int id);
        IQueryable<Order> GetAllOrdersIncludingAllDetailsAsQueryable();
    }
}