using TodoAPI.Data.Entities;
using TodoAPI.Data.Repositories.Interfaces;

namespace TodoAPI.Data.Repositories
{
    public class TodoRepository : BaseRepository<Todo, TodoContext>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)
        {
        }
    }
}
