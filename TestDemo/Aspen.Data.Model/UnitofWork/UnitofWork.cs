using System;
using System.Collections;
using System.Data.Entity;
using Aspen.Data.Model.Interfaces;
using Aspen.Data.Model.Repositories;

namespace Aspen.Data.Model.UnitofWork
{
    /// <summary>
    /// A base Unit of Work class.
    /// This Unit Of Work uses AspenModel dbContext to persist data.
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        protected readonly DbContext _context;
        protected readonly Guid _instanceId;
        protected bool _disposed;
        protected Hashtable _repositories;

        #endregion Private Fields

        #region Constuctor/Dispose

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _instanceId = Guid.NewGuid();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion


        /// <summary>
        /// Register a repository with Unit Of Work.
        /// Unit of work stores the repository in a collection.  
        /// During the transaction commit operation, UoW will try to invoke SaveChanges from all registered Repository
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="repository"></param>
        public void Register<TEntity>(IRepository<TEntity> repository) where TEntity : class
        {
            GetFromCache<TEntity, IRepository<TEntity>>(() => repository);
            return;
        }


        /// <summary>
        /// Provide a generic repository through this UoW
        /// The reposiotry instance will be registerd with the UoW
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return GetRepository<IRepository<TEntity>>(() => new Repository<TEntity>(_context));
        }


        /// <summary>
        /// Commit the transaction.  The core job of a UoW.
        /// Iterate through all registered Repository instances and invoke their SaveChanges.
        /// </summary>
        public void Save()
        {
            if (_repositories != null)
            {
                foreach (DictionaryEntry repo in _repositories)
                {
                    Type type = repo.Value.GetType();
                    System.Reflection.MethodInfo method = type.GetMethod("SaveChanges");
                    bool result = (bool)method.Invoke(repo.Value, null);
                    if (!result)
                    {
                        return;
                    }
                }
            }
            _context.SaveChanges();
        }


        /// <summary>
        /// Get repository instance of IRepository.  Use the factory to create an instance of repository
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="instanceFactory"></param>
        /// <returns></returns>
        protected TReturn GetRepository<TReturn>(Func<TReturn> instanceFactory = null)
        {
            return GetRepository<TReturn, TReturn>(instanceFactory);
        }

        /// <summary>
        /// Get repository instance of TEntity.  Use the factory to create an instance of repository
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="instanceFactory"></param>
        /// <returns></returns>
        protected TReturn GetRepository<TKey, TReturn>(Func<TReturn> instanceFactory = null)
        {
            TReturn instance = GetFromCache<TKey, TReturn>();

            if (instance != null)
            {
                return instance;
            }

            if (instanceFactory != null)
            {
                return instanceFactory();
            }

            return default(TReturn);
        }

        /// <summary>
        /// Check for the existence of instance of TReturn in _repositories array using TKey
        /// if not, use instanceFactory to create an instance and put it in _repositories
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="instanceFactory"></param>
        /// <returns></returns>
        protected TReturn GetFromCache<TKey, TReturn>(Func<TReturn> instanceFactory = null)
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TKey).Name;

            if (_repositories.ContainsKey(type))
            {
                return (TReturn)_repositories[type];
            }

            if (instanceFactory != null)
            {
                TReturn instance = instanceFactory();
                _repositories.Add(type, instance);

                return instance;
            }

            return default(TReturn);
        }
    }
}
