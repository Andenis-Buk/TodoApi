using Microsoft.EntityFrameworkCore.ChangeTracking;
using TodoApi.Data.TodoItems;
using TodoApi.Data.TodoItems.Models;
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
        var entitys = await _todoItemsData.GetTodoItems();
        return entitys.Select(entitys => entitys.ToModel());
    }

    public async Task<TodoItemModel> PostTodoItem(TodoItemModel model)
    {
        var entity = await _todoItemsData.PostTodoItem(model.ToEntity());
        return entity.ToModel();
    }

    public async Task<TodoItemModel> GetTodoItem(int id)
    {
        var entity = await _todoItemsData.GetTodoItem(id);
        return entity.ToModel();
    }

    public async Task<TodoItemModel> PutTodoItem(int id, TodoItemModel model)
    {
        var entity = await _todoItemsData.PutTodoItem(id, model.ToEntity());
        return entity.ToModel();
    }

    public async Task<TodoItemModel> DeleteTodoItem(int id)
    {
        var entity = await _todoItemsData.DeleteTodoItem(id);
        return entity.ToModel();
    }
}
