using Microsoft.AspNetCore.Mvc;
using Ticketing;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();


app.MapGet("/todos", ([FromServices] TodoService service) =>
{
    return Results.Ok(service.GetAllTodo());
});

app.MapGet("/todos/{id:int}", ([FromServices] TodoService service, [FromRoute] int id) =>
{
    var todo = service.GetById(id);
    {
        if (todo == null)
        {
            return Results.NotFound();
        }
    }
    return Results.Ok(todo);
});

app.MapGet("/todos/active", ([FromServices] TodoService service) =>
{
    return Results.Ok(service.GetAllTodo().Where(t => t.endDate == null));
});

app.MapPost("todos", ([FromBody] string todoTitle, [FromServices] TodoService service) =>
{
    return Results.Ok(service.AddTodo(todoTitle));
});

app.MapDelete("/todos/{id:int}", ([FromServices] TodoService service, int id) =>
{
    var result = service.Delete(id);
    if (result)
    {
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.MapPut("/todos/{id:int}", ([FromBody] Todo itemToModify, [FromServices] TodoService service, int id) =>
{
    service.Update(id, itemToModify);
    Results.NoContent();
});

app.Run();