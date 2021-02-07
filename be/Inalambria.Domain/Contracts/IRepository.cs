using Inalambria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inalambria.Domain.Contracts
{
    public interface IRepository<TEntity, TFilter> 
        where TEntity : Entity
        where TFilter : Filter
    {
        IEnumerable<TEntity> GetAll(TFilter filter);
        Task<IEnumerable<TEntity>> GetAllAsync(TFilter filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }

    public interface IRepositoryWithId<TEntity, TFilter> :IRepository<TEntity, TFilter>
        where TEntity : EntityWithId
        where TFilter : Filter
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
    }
}
