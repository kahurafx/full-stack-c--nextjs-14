using backend.Models;
using MongoDB.Driver;

namespace backend.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("TodoDb");
            _todos = database.GetCollection<Todo>("Todos");
        }

        public async Task<List<Todo>> GetAsync() => await _todos.Find(todo => true).ToListAsync();

        public async Task<Todo> CreateAsync(Todo todo)
        {
            await _todos.InsertOneAsync(todo);
            return todo;
        }
    }
}
