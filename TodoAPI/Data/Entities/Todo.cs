using TodoAPI.Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Data.Entities
{
    [Table("todo", Schema = "public")]
    public class Todo : IDBEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("completed")]
        public bool Completed { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("text")]
        public string Text { get; set; } = string.Empty;
    }
}
