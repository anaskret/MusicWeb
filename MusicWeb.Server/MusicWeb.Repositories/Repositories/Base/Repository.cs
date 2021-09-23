﻿using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities.Base;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _dbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}", ex);
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}", ex);
            }
        }

        public IList<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null)
        {
            var query = GetAll();
            query = func != null ? func(query) : query;

            return query.ToList();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                _dbContext.Entry<TEntity>(entity).State = EntityState.Detached;

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}", ex);
            }
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(AddRangeAsync)} entity must not be null");
            }

            try
            {
                foreach (var entity in entities)
                {
                    await _dbContext.AddAsync(entity);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Entities could not be saved: {ex.Message}", ex);
            }

            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();

                _dbContext.Entry<TEntity>(entity).State = EntityState.Detached;

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entity must not be null");
            }

            try
            {
                foreach (var entity in entities)
                {
                    _dbContext.Update(entity);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Entities could not be updated: {ex.Message}", ex);
            }

            return entities;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();

                return;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<TEntity>().FindAsync(keyValues);
        }

        public async Task<TEntity> GetByIdNoTrackingAsync(int id)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(prp => prp.Id == id);
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteRangeAsync)} entity must not be null");
            }

            try
            {
                foreach (var entity in entities)
                {
                    _dbContext.Remove(entity);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                    throw new Exception($"Entities could not be deleted: {ex.Message}", ex);
            }
        }
    }
}
