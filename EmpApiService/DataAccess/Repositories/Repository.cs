using EmpApiService.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmpApiService.DataAccess.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DataContext
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Get(long id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public IQueryable<TEntity> Queryable()
        {
            return context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> where)
        {
            return context.Set<TEntity>().Where(where).AsQueryable();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }
    }
}