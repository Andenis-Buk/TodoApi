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
        var models = await _todoItemsService.GetTodoItems();
        return models.Select(model => model.ToResponse()).ToList();
    }


    // POST: api/todo
    [HttpPost]
    public async Task<IActionResult> PostTodoItem(CreateTodoItemRequest request)
    {
        await _todoItemsService.PostTodoItem(request.toModel());

        return NoContent();
    }


    // GET: api/todo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemResponse>> GetTodoItem(int id)
    {
        try
        {
            var model = await _todoItemsService.GetTodoItem(id);
            return model.ToResponse();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // PUT: api/todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(int id, UpdateTodoItemRequest request)
    {
        try
        {
            await _todoItemsService.PutTodoItem(id, request.toModel());
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/todo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        try
        {
            await _todoItemsService.DeleteTodoItem(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
