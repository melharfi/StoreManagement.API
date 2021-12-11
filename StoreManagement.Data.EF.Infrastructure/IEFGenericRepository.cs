using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.EF.Infrastructure
{
    public interface IEFGenericRepository<TEntity> where TEntity : class
    {
        #region Read
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Create
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        #endregion

        #region UPDATE
        void UpdateAsync(TEntity entity);
        #endregion

        #region Delete
        void Remove(TEntity entity);
        void RemoveById(Guid id);
        void RemoveRange(IEnumerable<TEntity> entities);
        #endregion
    }
}
