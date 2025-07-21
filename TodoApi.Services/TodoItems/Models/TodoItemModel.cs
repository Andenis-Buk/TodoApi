using TodoApi.Data.TodoItems.Models;

namespace TodoApi.Services.TodoItems.Models;

public class TodoItemModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}

public static class TodoItemModelExtensions
{
    public static TodoItemModel ToModel(this TodoItemEntity entity)
    {
        return new TodoItemModel
        {
            Id = entity.Id,
            Title = entity.Title,
            DueDate = entity.DueDate,
            IsCompleted = entity.IsCompleted,
        };
    }

    public static TodoItemEntity ToEntity(this TodoItemModel model)
    {
        return new TodoItemEntity
        {
            Id = model.Id,
            Title = model.Title,
            DueDate = model.DueDate,
            IsCompleted = model.IsCompleted,
        };
    }
}
