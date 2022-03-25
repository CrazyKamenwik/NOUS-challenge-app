using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUS_challenge_app.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        public Task<List<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int id);
        public Task<TEntity> CreateAsync();
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task DeleteAsync(Guid id);
    }
}
