using System.Collections.Generic;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces.Specific
{
    public interface IOrderRepository:IRepository<Order>
    {
        IEnumerable<Order>  GetPriorityOrders();
        IEnumerable<Order> GetAllOrdersIncludingAllDetails();
        Order GetOrderByIdIncludingAllDetails(int id);

    }
}