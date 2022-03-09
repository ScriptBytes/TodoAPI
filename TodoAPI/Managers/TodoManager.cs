using AutoMapper;
using TodoAPI.Data;
using TodoAPI.Data.Entities;
using TodoAPI.Data.Repositories.Interfaces;
using TodoAPI.DTOs;
using TodoAPI.Managers;
using TodoAPI.Managers.Interfaces;

namespace TodoAPI.Managers
{
    public class TodoManager : BaseManager, ITodoManager
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public TodoManager(
            TodoContext context,
            ITodoRepository todoRepository,
            IMapper mapper
        ) : base(context, mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            await todoRepository.DeleteAsync(id);
            await SaveChangesAsync();
        }

        public async Task<List<TodoDTO>> GetIncomplete()
        {
            var record = todoRepository.GetAll()
                .Where(t => t.Completed == false);

            return mapper.Map<List<TodoDTO>>(record);
        }


        public async Task<TodoDTO> GetAsync(int id)
        {
            var record = await todoRepository.GetAsync(id);

            return mapper.Map<TodoDTO>(record);
        }

        public async Task<TodoDTO> InsertAsync(TodoPostDTO incomingRecord)
        {
            var mapped = mapper.Map<Todo>(incomingRecord);
            var inserted = await todoRepository.InsertAsync(mapped);
            await SaveChangesAsync();
            return mapper.Map<TodoDTO>(inserted);
        }

        public async Task<TodoDTO> UpdateAsync(int id, TodoPutDTO incomingRecord)
        {
            var existing = await todoRepository.GetAsync(id);
            var mapped = mapper.Map(incomingRecord, existing);

            await todoRepository.UpdateAsync(mapped);
            await SaveChangesAsync();

            return mapper.Map<TodoDTO>(mapped);
        }
    }
}
