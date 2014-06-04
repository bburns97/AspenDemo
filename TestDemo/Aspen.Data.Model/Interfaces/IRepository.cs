using System;

namespace Aspen.Data.Model.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Guid InstanceId { get; }
        TEntity GetDetachedEntity(params object[] keyValues);
        void Detach(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IRepositoryQuery<TEntity> Query();
        bool SaveChanges();
    }
}
