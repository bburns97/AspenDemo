using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aspen.Data.Model.Interfaces;

namespace Aspen.Data.Model.Repositories
{
    public sealed class RepositoryQuery<TEntity> : IRepositoryQuery<TEntity> where TEntity : class
    {
        private readonly IList<Expression<Func<TEntity, object>>> _includeProperties;
        private readonly Repository<TEntity> _repository;
        private readonly IList<Expression<Func<TEntity, bool>>> _filters;
        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> _orderByQueryable;
        
        public RepositoryQuery(Repository<TEntity> repository)
        {
            _repository = repository;
            _includeProperties = new List<Expression<Func<TEntity, object>>>();
            _filters = new List<Expression<Func<TEntity, bool>>>();
        }

        public IRepositoryQuery<TEntity> Filter(Expression<Func<TEntity, bool>> filter)
        {
            if (filter != null)
            {
                _filters.Add(filter);
            }
            return this;
        }

        public IRepositoryQuery<TEntity> Filter(IList<Expression<Func<TEntity, bool>>> filters)
        {
            if (filters != null)
            {
                foreach (var item in filters)
                {
                    _filters.Add(item);
                }
            }
            return this;
        }

        public IRepositoryQuery<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            _orderByQueryable = orderBy;
            return this;
        }

        public IRepositoryQuery<TEntity> Include(Expression<Func<TEntity, object>> expression)
        {
            _includeProperties.Add(expression);
            return this;
        }

        public IQueryable<TEntity> Get()
        {
            return _repository.Get(_filters, _orderByQueryable, _includeProperties);
        }
        public IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            return _repository.SqlQuery(query, parameters).AsQueryable();
        }
    }

}
