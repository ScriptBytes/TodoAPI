using Microsoft.EntityFrameworkCore;
using TodoAPI.Data.Entities;

namespace TodoAPI.Data
{
    public class TodoContext : DbContext
    {
        private readonly IConfiguration _config;

        public TodoContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                Environment.GetEnvironmentVariable(
                    _config.GetValue<string>("EnvKeys:DbUserConn")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
