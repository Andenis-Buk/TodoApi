using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool? IsCompleted {  get; set; }
}

public class TodoItemSetDTO
{
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    [Required]
    public DateOnly? DueDate { get; set; }
    [Required]
    public bool? IsCompleted { get; set; }
}

public class TodoItemGetDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}