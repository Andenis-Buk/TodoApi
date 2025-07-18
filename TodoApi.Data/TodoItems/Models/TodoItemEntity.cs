namespace TodoApi.Data.TodoItems.Models;

public class TodoItemEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}
