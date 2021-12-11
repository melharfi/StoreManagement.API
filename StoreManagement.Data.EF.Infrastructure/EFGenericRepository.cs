using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.EF.Infrastructure
{
    public class EFGenericRepository<TEntity> : IEFGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> dbSet;

        public EFGenericRepository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = this.Context.Set<TEntity>();
        }

        #region READ
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
        #endregion

        #region CREATE
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }
        #endregion

        #region UPDATE
        public void UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
        #endregion

        #region DELETE
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void RemoveById(Guid id)
        {
            var entityToDelete = dbSet.Find(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
            }
        }
        #endregion

    }
}
