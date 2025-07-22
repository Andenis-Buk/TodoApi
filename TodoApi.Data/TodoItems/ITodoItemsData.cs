using TodoApi.Data.TodoItems.Models;

namespace TodoApi.Data.TodoItems;

public interface ITodoItemsData
{
    Task<IEnumerable<TodoItemEntity>> GetTodoItems();

    Task<TodoItemEntity> PostTodoItem(TodoItemEntity entity);

    Task<TodoItemEntity> GetTodoItem(int id);

    Task<TodoItemEntity> PutTodoItem(int id, TodoItemEntity entity);

    Task<TodoItemEntity> DeleteTodoItem(int id);
}
