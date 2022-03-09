namespace TodoAPI.DTOs
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class TodoPostDTO
    {
        public bool Completed { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class TodoPutDTO
    {
        public bool Completed { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
