using Microsoft.EntityFrameworkCore;
using TodoAPI.Data.Entities.Interfaces;
using TodoAPI.Data.Repositories.Interfaces;

namespace TodoAPI.Data.Repositories
{
    public abstract class BaseRepository<T, UContext> : IBaseRepository<T> 
        where T : class, IDBEntity
        where UContext : DbContext
    {
        protected readonly UContext _context;
        public BaseRepository(UContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            var query = _context.Set<T>();

            return query;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>()
                                    .Where(r => r.Id == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _context.AddAsync(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetAsync(id);

            if (existing != null)
            {
                _context.Set<T>().Remove(existing);
            }
        }
    }
}
