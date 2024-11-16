using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get() => await _todoService.GetAsync();

        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo todo)
        {
            await _todoService.CreateAsync(todo);
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }
    }
}
