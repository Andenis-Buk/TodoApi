using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.Controllers.TodoItems.Models;
using TodoApi.Services.TodoItems;

namespace TodoApi.Application.Controllers.TodoItems;

[Route("api/todo")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly ITodoItemsService _todoItemsService;

    public TodoItemsController(ITodoItemsService todoItemsService)
    {
        _todoItemsService = todoItemsService;
    }

    //GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemResponse>>> GetTodoItems()
    {
        return (await _todoItemsService.GetTodoItems()).Select(model => model.ToResponse()).ToList();
    }

    /*
    // POST: api/todo
    [HttpPost]
    public async Task<IActionResult> PostTodoItem(TodoItemSetDTO todoItemSetDTO)
    {
        var todoItem = new TodoItem
        {
            Title = todoItemSetDTO.Title,
            DueDate = todoItemSetDTO.DueDate,
            IsCompleted = todoItemSetDTO.IsCompleted,
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // GET: api/todo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemGetDTO>> GetTodoItem(int id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return TodoItemToGetDTO(todoItem);
    }

    // PUT: api/todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(int id, TodoItemSetDTO todoItemSetDTO)
    {

        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Title = todoItemSetDTO.Title;
        todoItem.DueDate = todoItemSetDTO.DueDate;
        todoItem.IsCompleted = todoItemSetDTO.IsCompleted;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/todo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    */
}
