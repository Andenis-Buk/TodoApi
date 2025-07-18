using Microsoft.EntityFrameworkCore.ChangeTracking;
using TodoApi.Data.TodoItems;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Services.TodoItems;

public class TodoItemsService : ITodoItemsService
{
    private readonly ITodoItemsData _todoItemsData;

    public TodoItemsService(ITodoItemsData todoItemsData)
    {
        _todoItemsData = todoItemsData;
    }

    public async Task<IEnumerable<TodoItemModel>> GetTodoItems()
    {
        return (await _todoItemsData.GetTodoItems()).Select(entity => entity.ToModel());
    }
}
