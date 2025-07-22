namespace TodoApi.Data.TodoItems.Models;

public class TodoItemEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}

public static class TodoItemEntityExtensions
{
    public static void UpdateEntity(this TodoItemEntity todoItem, TodoItemEntity entity)
    {
        todoItem.Title = entity.Title;
        todoItem.DueDate = entity.DueDate;
        todoItem.IsCompleted = entity.IsCompleted;
    }
}