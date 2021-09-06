using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Pizzeria.Core.Interfaces.Specific;

namespace Pizzeria.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPizzaRepository Pizzas { get; }
        Task CompleteAsync();
    }
}