// builder
var builder = WebApplication.CreateBuilder(args);

// The app itself
var app = builder.Build();

// todos
var todos = new List<Todo>();

// POST req to create one todo
app.MapPost(
    "/todos",
    (Todo todo) =>
    {
        todos.Add(todo);
        return todo;
    }
);

// DELETE request to delete a todo by id
app.MapDelete(
    "/todos/{id}",
    (int id) =>
    {
        var deletedCount = todos.RemoveAll(item => item.id == id);
        return deletedCount > 0 ? Results.NoContent() : Results.NotFound();
    }
);

app.MapPut(
    "/todos/{id}",
    (int id, Todo updatedTodo) =>
    {
        var todo = todos.FirstOrDefault(t => t.id == id);
        if (todo is null)
            return Results.NotFound();

        // Manually update the properties
        todo.name = updatedTodo.name;
        todo.isCompleted = updatedTodo.isCompleted;

        return Results.Ok(todo);
    }
);

app.MapGet("/todos", () => todos);

app.Run();

public class Todo
{
    public int id { get; set; }
    public string name { get; set; }
    public bool isCompleted { get; set; }
}
