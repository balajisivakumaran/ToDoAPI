using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDODb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/todo", async(AppDbContext context) => {

   var toDoItems = await context.ToDoItems.ToListAsync();

   return Results.Ok(toDoItems); 
});

app.MapPost("api/v1/todo", async(AppDbContext context, ToDoItem toDoItem) => {

    if(toDoItem == null) return Results.BadRequest();

    await context.ToDoItems.AddAsync(toDoItem);

    await context.SaveChangesAsync();

    return Results.Created($"api/v1/todo/{toDoItem.Id}", toDoItem);

});

app.Run();


