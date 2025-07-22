using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoApi.Application.Controllers.TodoItems.Models;
using TodoApi.Data.TodoItems;
using TodoApi.Data.TodoItems.Models;
using TodoApi.Services.TodoItems;
using TodoApi.Services.TodoItems.Models;
using Xunit;

namespace TodoApi.UnitTests.Services;

public class TodoItemsServiceTests
{
    private readonly Mock<ITodoItemsData> _mockData;
    private readonly TodoItemsService _service;

    public TodoItemsServiceTests()
    {
        _mockData = new Mock<ITodoItemsData>();
        _service = new TodoItemsService(_mockData.Object);
    }

    [Fact]
    public async Task GetTodoItems_ReturnsListOfTodoItemModels()
    {
        // Arrange
        var entities = new List<TodoItemEntity>
        {
            new TodoItemEntity
            {
                Id = 1,
                Title = "Test 1",
                DueDate = DateOnly.FromDateTime(DateTime.Today),
                IsCompleted = false
            },
            new TodoItemEntity
            {
                Id = 2,
                Title = "Test 2",
                DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                IsCompleted = true
            }
        };

        _mockData.Setup(d => d.GetTodoItems()).ReturnsAsync(entities);

        // Act
        var result = await _service.GetTodoItems();

        // Assert
        var data = Assert.IsType<List<TodoItemModel>>(result.ToList());
        Assert.Equal(2, data.Count);
        Assert.Equal("Test 1", data[0].Title);
        Assert.Equal("Test 2", data[1].Title);
    }

    [Fact]
    public async Task PostTodoItem_ReturnsCreatedTodoItemModel()
    {
        // Arrange
        var model = new TodoItemModel
        {
            Title = "New",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = false
        };

        var entity = new TodoItemEntity
        {
            Id = 10,
            Title = "New",
            DueDate = model.DueDate,
            IsCompleted = model.IsCompleted
        };

        _mockData.Setup(d => d.PostTodoItem(It.IsAny<TodoItemEntity>())).ReturnsAsync(entity);

        // Act
        var result = await _service.PostTodoItem(model);

        // Assert
        var value = Assert.IsType<TodoItemModel>(result);
        Assert.Equal(10, value.Id);
        Assert.Equal(model.Title, value.Title);
    }

    [Fact]
    public async Task GetTodoItem_ReturnsTodoItemModel()
    {
        // Arrange
        var entity = new TodoItemEntity
        {
            Id = 1,
            Title = "Test",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = true
        };

        _mockData.Setup(d => d.GetTodoItem(1)).ReturnsAsync(entity);

        // Act
        var result = await _service.GetTodoItem(1);

        // Assert
        var value = Assert.IsType<TodoItemModel>(result);
        Assert.Equal(1, value.Id);
    }

    [Fact]
    public async Task PutTodoItem_ReturnsUpdatedTodoItemModel()
    {
        // Arrange
        var model = new TodoItemModel
        {
            Title = "Updated",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = true
        };

        var updatedEntity = new TodoItemEntity
        {
            Id = 1,
            Title = "Updated",
            DueDate = model.DueDate,
            IsCompleted = model.IsCompleted
        };

        _mockData.Setup(d => d.PutTodoItem(1, It.IsAny<TodoItemEntity>())).ReturnsAsync(updatedEntity);

        // Act
        var result = await _service.PutTodoItem(1, model);

        // Assert
        var value = Assert.IsType<TodoItemModel>(result);
        Assert.Equal("Updated", value.Title);
    }

    [Fact]
    public async Task DeleteTodoItem_ReturnsDeletedTodoItemModel()
    {
        // Arrange
        var deletedEntity = new TodoItemEntity
        {
            Id = 1,
            Title = "To be deleted",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = true
        };

        _mockData.Setup(d => d.DeleteTodoItem(2)).ReturnsAsync(deletedEntity);

        // Act
        var result = await _service.DeleteTodoItem(2);

        // Assert
        var value = Assert.IsType<TodoItemModel>(result);
        Assert.Equal(1, value.Id);
    }
}
