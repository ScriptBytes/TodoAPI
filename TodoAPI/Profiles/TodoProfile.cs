using AutoMapper;
using TodoAPI.Data.Entities;
using TodoAPI.DTOs;

namespace TodoAPI.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDTO>();
            CreateMap<TodoPutDTO, Todo>();
            CreateMap<TodoPostDTO, Todo>();
        }
    }
}
