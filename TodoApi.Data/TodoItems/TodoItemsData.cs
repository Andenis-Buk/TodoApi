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
}
