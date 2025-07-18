using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Services.TodoItems;

public interface ITodoItemsService
{
    Task<IEnumerable<TodoItemModel>> GetTodoItems();
}
