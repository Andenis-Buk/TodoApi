using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Application.Models;

namespace TodoApi.Application.Controllers;

[Route("api/todo")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoItemsController(TodoContext context)
    {
        _context = context;
    }

    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemGetDTO>>> GetTodoItems()
    {
        return await _context.TodoItems
            .Select(x => TodoItemToGetDTO(x))
            .ToListAsync();
    }

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

    private static TodoItemGetDTO TodoItemToGetDTO(TodoItem todoItem)
    {
        return new TodoItemGetDTO
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
        };
    }
}
