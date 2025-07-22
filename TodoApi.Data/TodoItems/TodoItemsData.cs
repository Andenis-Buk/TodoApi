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

    public async Task<TodoItemEntity> PostTodoItem(TodoItemEntity entity)
    {
        _todoContext.TodoItems.Add(entity);
        await _todoContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TodoItemEntity> GetTodoItem(int id)
    {
        return await _todoContext.TodoItems.FindAsync(id) ?? throw new KeyNotFoundException();
    }

    public async Task<TodoItemEntity> PutTodoItem(int id, TodoItemEntity entity)
    {
        var todoItem = await _todoContext.TodoItems.FindAsync(id) ?? throw new KeyNotFoundException();

        todoItem.UpdateEntity(entity);
        await _todoContext.SaveChangesAsync();

        return todoItem;
    }

    public async Task<TodoItemEntity> DeleteTodoItem(int id)
    {
        var todoItem = await _todoContext.TodoItems.FindAsync(id) ?? throw new KeyNotFoundException();

        _todoContext.TodoItems.Remove(todoItem);
        await _todoContext.SaveChangesAsync();

        return todoItem;
    }
}
