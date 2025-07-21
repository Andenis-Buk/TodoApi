using Microsoft.EntityFrameworkCore;
using TodoApi.Data.TodoItems.Models;

namespace TodoApi.Data.TodoItems;

public class TodoItemsData : ITodoItemsData
{
    private readonly TodoContext _todoContext;

    public TodoItemsData(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }

    public async Task<IEnumerable<TodoItemEntity>> GetTodoItems()
    {
        return await _todoContext.TodoItems.ToListAsync();
    }

    public async Task PostTodoItem(TodoItemEntity entity)
    {
        _todoContext.TodoItems.Add(entity);
        await _todoContext.SaveChangesAsync();
    }

    public async Task<TodoItemEntity?> GetTodoItem(int id)
    {
        return await _todoContext.TodoItems.FindAsync(id);
    }

    public async Task PutTodoItem(int id, TodoItemEntity entity)
    {
        var todoItem = await _todoContext.TodoItems.FindAsync(id);

        if (todoItem == null)
        {

            throw new KeyNotFoundException($"Todo item with id {id} not found.");
        }

        todoItem.UpdateEntity(entity);
        await _todoContext.SaveChangesAsync();
    }
}
