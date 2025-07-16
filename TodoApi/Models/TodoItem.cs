using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly DueDate { get; set; }
    public bool IsCompleted {  get; set; }
}