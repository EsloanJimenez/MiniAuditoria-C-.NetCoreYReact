using ejpservice.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ejpservice.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private DbSet<TEntity> _entities;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
            this._entities = this.context.Set<TEntity>();
        }
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public virtual async Task<TEntity> Get(int Id)
        {
            return await _entities.FindAsync(Id);
        }
        
        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.Where(filter).ToListAsync();
        }

        public virtual async Task Save(TEntity entity)
        {
            _entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await context.SaveChangesAsync();
        }
        public virtual async Task Remove(TEntity entity)
        {
            this._entities.Remove(entity);
        }
        public virtual async Task SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
