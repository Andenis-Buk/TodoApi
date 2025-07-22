using TodoApi.Data.TodoItems.Models;

namespace TodoApi.Data.TodoItems;

public interface ITodoItemsData
{
    Task<IEnumerable<TodoItemEntity>> GetTodoItems();

    Task PostTodoItem(TodoItemEntity entity);

    Task<TodoItemEntity> GetTodoItem(int id);

    Task PutTodoItem(int id, TodoItemEntity entity);

    Task DeleteTodoItem(int id);
}
