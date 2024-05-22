using Microsoft.EntityFrameworkCore;
using UpSoluctions.Data;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SystemContext _context;

        public GenericRepository(SystemContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(params object[] keys)
        {
            return await _context.FindAsync<TEntity>(keys) ?? throw new KeyNotFoundException();
        }

        public async Task<TEntity> SearchByIdAsync(params object[] keys)
        {
            return await _context.FindAsync<TEntity>(keys) ?? throw new KeyNotFoundException();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, params object[] keys)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(params object[] keys)
        {
            TEntity entity = await GetByIdAsync(keys);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
