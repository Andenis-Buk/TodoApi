using TodoApi.Data.TodoItems.Models;

namespace TodoApi.Data.TodoItems;

public interface ITodoItemsData
{
    Task<IEnumerable<TodoItemEntity>> GetTodoItems();
}
