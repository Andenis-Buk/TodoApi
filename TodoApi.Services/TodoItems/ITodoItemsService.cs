using TodoApi.Data.TodoItems.Models;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Services.TodoItems;

public interface ITodoItemsService
{
    Task<IEnumerable<TodoItemModel>> GetTodoItems();

    Task PostTodoItem(TodoItemModel model);

    Task<TodoItemModel?> GetTodoItem(int id);

    Task PutTodoItem(int id, TodoItemModel model);
}
