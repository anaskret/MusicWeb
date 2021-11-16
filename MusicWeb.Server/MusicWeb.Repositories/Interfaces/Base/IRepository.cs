using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);

        Task<TEntity> AddAsync(TEntity entity);

        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entities);

        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdNoTrackingAsync(int id);
    }
}
