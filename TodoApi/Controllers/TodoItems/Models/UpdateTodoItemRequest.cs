using System.ComponentModel.DataAnnotations;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Application.Controllers.TodoItems.Models;

public class UpdateTodoItemRequest
{
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    [Required]
    public DateOnly? DueDate { get; set; }
    [Required]
    public bool? IsCompleted { get; set; }
}

public static class UpdateTodoItemRequestExtensions
{
    public static TodoItemModel toModel(this UpdateTodoItemRequest request)
    {
        return new TodoItemModel
        {
            Title = request.Title,
            DueDate = request.DueDate,
            IsCompleted = request.IsCompleted,
        };
    }
}