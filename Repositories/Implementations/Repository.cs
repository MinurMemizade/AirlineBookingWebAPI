using AirlineBookingWebApi.Context;
using AirlineBookingWebApi.Models.Common;
using AirlineBookingWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingWebApi.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly AppDBContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            T entity=await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); 
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            T entity=await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
