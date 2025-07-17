using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Application.Controllers;
using TodoApi.Application.Models;
using Xunit;


namespace TodoApi.UnitTests.Controllers;

public class TodoItemControllerTest
{

    private TodoContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(databaseName: "TodoTestDb")
            .Options;

        var context = new TodoContext(options);

        // Seed data
        context.TodoItems.AddRange(
            new TodoItem { Id = 1, Title = "Test 1", IsCompleted = false },
            new TodoItem { Id = 2, Title = "Test 2", IsCompleted = true }
        );
        context.SaveChanges();

        return context;
    }

    [Fact]
    public async Task GetTodoItems_ReturnsAllItems()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new TodoItemsController(context);

        // Act
        var result = await controller.GetTodoItems();

        // Assert
        var items = Assert.IsType<List<TodoItemGetDTO>>(result.Value);
        Assert.Equal(2, items.Count);
    }
}