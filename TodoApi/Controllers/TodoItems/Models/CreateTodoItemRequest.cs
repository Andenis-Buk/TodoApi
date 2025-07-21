using System.ComponentModel.DataAnnotations;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.Application.Controllers.TodoItems.Models;

public class CreateTodoItemRequest
{
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    [Required]
    public DateOnly? DueDate { get; set; }
    [Required]
    public bool? IsCompleted { get; set; }
}

public static class CreateTodoItemRequestExtensions
{
    public static TodoItemModel toModel(this CreateTodoItemRequest request)
    {
        return new TodoItemModel
        {
            Title = request.Title,
            DueDate = request.DueDate,
            IsCompleted = request.IsCompleted,
        };
    }
}