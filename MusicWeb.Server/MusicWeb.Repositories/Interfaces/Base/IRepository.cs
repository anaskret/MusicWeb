using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        IList<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entities);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdNoTrackingAsync(int id);
    }
}
