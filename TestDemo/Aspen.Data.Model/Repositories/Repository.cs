using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Aspen.Data.Model.Interfaces;

namespace Aspen.Data.Model.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly Guid _instanceId;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _instanceId = Guid.NewGuid();
        }

        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        
        public virtual TEntity GetDetachedEntity(params object[] keyValues)
        {
            var e = _dbSet.Find(keyValues);
            var oc = (IObjectContextAdapter)_context;
            oc.ObjectContext.Detach(e);
            return e;
        }

        public virtual void Detach(TEntity entity)
        {
            var oc = (IObjectContextAdapter)_context;
            oc.ObjectContext.Detach(entity);
        }

        
        public virtual IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry<TEntity>(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity entity)
        {
            //_dbSet.Attach(entity);
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        
        public virtual void Delete(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public virtual IRepositoryQuery<TEntity> Query()
        {
            var repositoryGetFluentHelper = new RepositoryQuery<TEntity>(this);
            return repositoryGetFluentHelper;
        }

        internal IQueryable<TEntity> Get(
            IList<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IList<Expression<Func<TEntity, object>>> includeProperties = null
            )
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties)
                {
                    query = query.Include(includeProp);
                    //includeProperties.ForEach(i => query = query.Include(i));
                }
            }

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }


            if (orderBy != null)
                query = orderBy(query);


            return query;
        }

        internal async Task<IEnumerable<TEntity>> GetAsync(
            IList<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IList<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null)
        {
            return Get(filters, orderBy, includeProperties).AsEnumerable();
        }


        public virtual bool SaveChanges()
        {
            return true;
        }
    }
}
