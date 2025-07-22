using TodoApi.Data.TodoItems.Models;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Services.TodoItems;

public interface ITodoItemsService
{
    Task<IEnumerable<TodoItemModel>> GetTodoItems();

    Task<TodoItemModel> PostTodoItem(TodoItemModel model);

    Task<TodoItemModel> GetTodoItem(int id);

    Task<TodoItemModel> PutTodoItem(int id, TodoItemModel model);

    Task<TodoItemModel> DeleteTodoItem(int id);
}
