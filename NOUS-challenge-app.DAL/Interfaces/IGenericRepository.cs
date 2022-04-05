using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NOUS_challenge_app.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        public Task<List<TEntity>> GetAllAsync();
        public Task<List<TEntity>> GetByCustomerIdAsync(int id);
        public Task<TEntity> GetByIdAsync(Guid id);
        public Task<TEntity> CreateAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task DeleteAsync(Guid id);
    }
}