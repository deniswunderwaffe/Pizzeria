using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _db;

        public EfRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public T GetById(int id)
        {
            var entity = _db.Set<T>().Find(id);
            return entity;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            var entity = _db.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var queryableEntities = _db.Set<T>()
                .Where(expression)
                .AsNoTracking();
            return queryableEntities;
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
            var queryableEntities = _db.Set<T>().AsQueryable();
            return queryableEntities;
        }

        public int CountAll()
        {
            var count = _db.Set<T>().Count();
            return count;
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}