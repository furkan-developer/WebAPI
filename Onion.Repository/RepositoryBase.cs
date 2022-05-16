using Microsoft.EntityFrameworkCore;
using Onion.Contrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(TEntity entity) => _repositoryContext.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity) => _repositoryContext.Set<TEntity>().Remove(entity);

        public IQueryable<TEntity> FindAll(bool trackChanges) => 
            !trackChanges ?
            _repositoryContext.Set<TEntity>().AsNoTracking() :
            _repositoryContext.Set<TEntity>();

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _repositoryContext.Set<TEntity>().Where(expression).AsNoTracking() :
            _repositoryContext.Set<TEntity>().Where(expression);

        public void Update(TEntity entity) => _repositoryContext.Set<TEntity>().Update(entity);
    }
}
