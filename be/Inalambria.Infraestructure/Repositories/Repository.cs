using Microsoft.EntityFrameworkCore;
using Inalambria.Domain;
using Inalambria.Domain.Entities;
using Inalambria.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inalambria.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TFilter> : IRepository<TEntity, TFilter>
        where TEntity : Entity
        where TFilter : Filter
    {
        readonly InalambriaDbContext _nexosDbContext;
        public Repository(InalambriaDbContext context)
        {
            _nexosDbContext = context;
        }
        public abstract DbSet<TEntity> Dbset { get; }

        public virtual void Add(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Dbset.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll(TFilter filter)
        {
            return Dbset.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(TFilter filter)
        {
            return await Dbset.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            Dbset.Update(entity);
        }

        public void SaveChanges()
        {
            _nexosDbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _nexosDbContext.SaveChangesAsync();
        }
    }

    public abstract class RepositoryWithId<TEntity, TFilter> : Repository<TEntity, TFilter>, IRepositoryWithId<TEntity, TFilter>
        where TEntity : EntityWithId
        where TFilter : Filter
    {
        public RepositoryWithId(InalambriaDbContext context) : base(context)
        {
        }

        public virtual TEntity Get(int id)
        {
            return Dbset.FirstOrDefault(e => e.Id == id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Dbset.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}