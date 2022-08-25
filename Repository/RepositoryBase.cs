using Contracts.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext DbContext;

        public RepositoryBase(AppDbContext repositoryContext)
        {
            DbContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? DbContext.Set<T>().AsNoTracking() : DbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            var query = DbContext.Set<T>().Where(expression);

            return trackChanges ? query : query.AsNoTracking();
        }

        public void Create(T entity) => DbContext.Set<T>().Add(entity);

        public void Update(T entity) => DbContext.Set<T>().Update(entity);

        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);
    }
}
