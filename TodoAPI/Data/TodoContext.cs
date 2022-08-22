using Microsoft.EntityFrameworkCore;
using TodoAPI.Data.Entities;

namespace TodoAPI.Data
{
    public class TodoContext : DbContext
    {
        private readonly IConfiguration config;

        public TodoContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envVariableName = config.GetValue<string>("EnvKeys:TodoDbConn");
            var connectionString = Environment.GetEnvironmentVariable(envVariableName);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"The environment variable {envVariableName} is not set.");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
