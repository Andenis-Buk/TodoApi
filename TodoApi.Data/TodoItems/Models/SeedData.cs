using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Data.TodoItems.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new TodoContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<TodoContext>>()))
        {
            // Look for any movies.
            if (context.TodoItems.Any())
            {
                return;   // DB has been seeded
            }
            context.TodoItems.AddRange(
                new TodoItemEntity
                {
                    Title = "Wash dishes",
                    DueDate = DateOnly.Parse("2025-7-13"),
                    IsCompleted = true,
                },
                new TodoItemEntity
                {
                    Title = "Takeout trash",
                    DueDate = DateOnly.Parse("2025-7-14"),
                    IsCompleted = true,
                },
                new TodoItemEntity
                {
                    Title = "Clean bathroom",
                    DueDate = DateOnly.Parse("2025-7-17"),
                    IsCompleted = false,
                }
            );
            context.SaveChanges();
        }
    }
}