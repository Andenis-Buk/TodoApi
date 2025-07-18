using Microsoft.VisualBasic;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Application.Controllers.TodoItems.Models;

public class TodoItemResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}

public static class TodoItemResponseExtensions
{
    public static TodoItemResponse ToResponse(this TodoItemModel model)
    {
        return new TodoItemResponse
        {
            Id = model.Id,
            Title = model.Title,
            DueDate = model.DueDate,
            IsCompleted = model.IsCompleted,
        };
    }
}