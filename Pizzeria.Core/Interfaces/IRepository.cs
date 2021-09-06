using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        public bool SaveAll();
        T GetById(int id);
        // T GetByIdWithInclude(int id,params Expression<Func<T, object>>[] includeProperties);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        int CountAll();
    }
}