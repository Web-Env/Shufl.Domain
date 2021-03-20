using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Repositories.Contexts;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ShuflRepositoryContext _ShuflContext;
        public RepositoryBase(ShuflRepositoryContext context)
        {
            _ShuflContext = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _ShuflContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetManyByIdAsync(IEnumerable<Guid> ids)
        {
            return await _ShuflContext.Set<T>().Where(x => ids.Contains(EF.Property<Guid>(x, "Id"))).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize)
        {
            var offset = pageSize * (pageNumber - 1);

            return await _ShuflContext.Set<T>()
                .Skip(offset)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _ShuflContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _ShuflContext.Set<T>().Add(entity);
            await _ShuflContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            _ShuflContext.Set<T>().AddRange(entities);
            await _ShuflContext.SaveChangesAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _ShuflContext.Set<T>().Update(entity);
            await _ShuflContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _ShuflContext.Set<T>().UpdateRange(entities);
            await _ShuflContext.SaveChangesAsync();
            return entities;
        }

        public async Task RemoveAsync(T entity)
        {
            _ShuflContext.Set<T>().Remove(entity);
            await _ShuflContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id).ConfigureAwait(false);
            await RemoveAsync(entity).ConfigureAwait(false);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _ShuflContext.RemoveRange(entities);
            await _ShuflContext.SaveChangesAsync();
        }

        public async Task RemoveRangeByIdAsync(IEnumerable<Guid> ids)
        {
            var entities = await GetManyByIdAsync(ids).ConfigureAwait(false);
            await RemoveRangeAsync(entities).ConfigureAwait(false);
        }
    }
}
