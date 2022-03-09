using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Data.Repositories;
using TodoAPI.Data.Repositories.Interfaces;
using TodoAPI.Managers;
using TodoAPI.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<TodoContext>();
builder.Services.AddScoped<ITodoManager, TodoManager>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
