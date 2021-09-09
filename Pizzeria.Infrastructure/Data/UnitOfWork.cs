using System;
using System.Threading.Tasks;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations;

namespace Pizzeria.Infrastructure.Data
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        //TODO do i need this class?
        private readonly ApplicationDbContext _db;
        
        public IPizzaRepository Pizzas {get; private set;}

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            Pizzas = new PizzaRepository(_db);           
        }

        public bool Complete()
        {
             return _db.SaveChanges()>=1;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}