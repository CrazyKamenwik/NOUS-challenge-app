using Microsoft.EntityFrameworkCore;
using NOUS_challenge_app.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOUS_challenge_app.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected AppDbContext AppDbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        public GenericRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            DbSet = AppDbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<TEntity>> GetByCustomerIdAsync(int id)
        {
            var entity = DbSet.Where(x => x.CustomerId == id).ToListAsync();
            return await entity;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = DbSet.FindAsync(id);
            return await entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await AppDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            AppDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }

            await AppDbContext.SaveChangesAsync();
        }
    }
}