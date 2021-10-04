using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations
{
    public class EfRepository<T>:IRepository<T> where T:BaseEntity
    {
        protected readonly ApplicationDbContext _db;

        public EfRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        // public T GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includeProperties)
        // {
        //     var query = IncludeProperties(includeProperties);
        //     //return _db.Set<T>().Find(id);
        //     return query.FirstOrDefault(entity => entity.Id == id);
        // }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public int CountAll()
        {
            return _db.Set<T>().Count();
        }
        public bool SaveAll()
        {
            return  _db.SaveChanges() >= 0;
        }
        // private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        // {
        //     IQueryable<T> entities = _db.Set<T>();
        //     foreach (var includeProperty in includeProperties)
        //     {
        //         entities = entities.Include(includeProperty);
        //     }
        //     return entities;
        // }
    }
}