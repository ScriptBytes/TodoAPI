using TodoAPI.Data.Entities;
using TodoAPI.DTOs;

namespace TodoAPI.Managers.Interfaces
{
    public interface ITodoManager
    {
        Task<TodoDTO> GetAsync(int id);
        Task<TodoDTO> InsertAsync(TodoPostDTO incomingRecord);
        Task<TodoDTO> UpdateAsync(int id, TodoPutDTO rec);
        Task DeleteAsync(int id);
        Task<List<TodoDTO>> GetIncomplete();
    }
}
