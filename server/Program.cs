// builder
var builder = WebApplication.CreateBuilder(args);

List todos = new List<String>();

// The app itself
var app = builder.Build();

// POST req to create one todo
app.MapPost(
    "/todos",
    (data) =>
    {
        todos.Add(data);
        return "success";
    }
);

app.MapGet("/todos", () => { });

app.Run();
