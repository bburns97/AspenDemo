using System;

namespace Aspen.Data.Model.Interfaces
{
    /// <summary>
    /// Define the core behavior of a unit of work class.
    /// Provide functions to:
    /// - Commit a transaction 
    /// - Access to internal repositories
    /// - Register external repositories involve in transaction
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Register a repository with a unit of work.
        /// A unit of work should keep track of all repositories to invoke their commit transaction method when needed
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="repository"></param>
        void Register<TEntity>(IRepository<TEntity> repository) where TEntity : class;

        /// <summary>
        /// An access point to retrieve a repository
        /// All consumer classes of unit of work should get domain entity repository through this function
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        /// <summary>
        /// Core function of a unit of work.
        /// Commit a transaction
        /// </summary>
        void Save();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        void Dispose(bool disposing);
    }
}
