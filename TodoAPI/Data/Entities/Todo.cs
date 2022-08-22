using TodoAPI.Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Data.Entities
{
    public class Todo : IDBEntity
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; } = string.Empty;
    }
}
