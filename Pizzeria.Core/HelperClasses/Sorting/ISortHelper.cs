using System.Linq;

namespace Pizzeria.Core.HelperClasses.Sorting
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}