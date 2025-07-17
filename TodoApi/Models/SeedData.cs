using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TodoApi.Application.Models;

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
                new TodoItem
                {
                    Title = "Wash dishes",
                    DueDate = DateOnly.Parse("2025-7-13"),
                    IsCompleted = true,
                },
                new TodoItem
                {
                    Title = "Takeout trash",
                    DueDate = DateOnly.Parse("2025-7-14"),
                    IsCompleted = true,
                },
                new TodoItem
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