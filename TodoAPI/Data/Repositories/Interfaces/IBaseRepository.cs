using TodoAPI.Data.Entities.Interfaces;

namespace TodoAPI.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IDBEntity
    {
        IQueryable<T> GetAll();
        Task<T> InsertAsync(T rec);
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(T rec);
        Task DeleteAsync(int id);
    }
}
