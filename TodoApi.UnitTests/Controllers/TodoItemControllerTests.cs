using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.Controllers.TodoItems;
using TodoApi.Application.Controllers.TodoItems.Models;
using TodoApi.Services.TodoItems;
using TodoApi.Services.TodoItems.Models;

namespace TodoApi.UnitTests.Controllers;

public class TodoItemsControllerTests
{
    private readonly Mock<ITodoItemsService> _mockService;
    private readonly TodoItemsController _controller;

    public TodoItemsControllerTests()
    {
        _mockService = new Mock<ITodoItemsService>();
        _controller = new TodoItemsController(_mockService.Object);
    }

    [Fact]
    public async Task GetTodoItems_ReturnsListOfTodoItemResponses()
    {
        // Arrange
        var items = new List<TodoItemModel>
        {
            new TodoItemModel 
            { 
                Id = 1, 
                Title = "Test 1", 
                DueDate = DateOnly.FromDateTime(DateTime.Today), 
                IsCompleted = false 
            },
            new TodoItemModel 
            { 
                Id = 2, 
                Title = "Test 2", 
                DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)), 
                IsCompleted = true 
            }
        };
        _mockService.Setup(s => s.GetTodoItems()).ReturnsAsync(items);

        // Act
        var result = await _controller.GetTodoItems();

        // Assert
        var okResult = Assert.IsType<ActionResult<IEnumerable<TodoItemResponse>>>(result);
        var data = Assert.IsType<List<TodoItemResponse>>(okResult.Value);
        Assert.Equal(2, data.Count);
        Assert.Equal("Test 1", data[0].Title);
        Assert.Equal("Test 2", data[1].Title);
    }

    [Fact]
    public async Task PostTodoItem_ReturnsCreatedTodoItemResponse()
    {
        // Arrange
        var request = new CreateTodoItemRequest
        {
            Title = "New Item",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = false
        };

        var model = new TodoItemModel
        {
            Id = 3,
            Title = request.Title,
            DueDate = request.DueDate,
            IsCompleted = request.IsCompleted
        };

        _mockService.Setup(s => s.PostTodoItem(It.IsAny<TodoItemModel>())).ReturnsAsync(model);

        // Act
        var result = await _controller.PostTodoItem(request);

        // Assert
        var response = Assert.IsType<ActionResult<TodoItemResponse>>(result);
        var value = Assert.IsType<TodoItemResponse>(response.Value);
        Assert.Equal(3, value.Id);
        Assert.Equal(request.Title, value.Title);
    }

    [Fact]
    public async Task GetTodoItem_ValidId_ReturnsTodoItemResponse()
    {
        // Arrange
        var model = new TodoItemModel
        {
            Id = 1,
            Title = "Test",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = false
        };

        _mockService.Setup(s => s.GetTodoItem(1)).ReturnsAsync(model);

        // Act
        var result = await _controller.GetTodoItem(1);

        // Assert
        var response = Assert.IsType<ActionResult<TodoItemResponse>>(result);
        var value = Assert.IsType<TodoItemResponse>(response.Value);
        Assert.Equal(1, value.Id);
    }

    [Fact]
    public async Task GetTodoItem_InvalidId_ReturnsNotFound()
    {
        // Arrange
        _mockService.Setup(s => s.GetTodoItem(999)).ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.GetTodoItem(999);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PutTodoItem_ValidId_ReturnsUpdatedTodoItemResponse()
    {
        // Arrange
        var request = new UpdateTodoItemRequest
        {
            Title = "Updated",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = true
        };

        var model = new TodoItemModel
        {
            Id = 1,
            Title = request.Title,
            DueDate = request.DueDate,
            IsCompleted = request.IsCompleted
        };

        _mockService.Setup(s => s.PutTodoItem(1, It.IsAny<TodoItemModel>())).ReturnsAsync(model);

        // Act
        var result = await _controller.PutTodoItem(1, request);

        // Assert
        var response = Assert.IsType<ActionResult<TodoItemResponse>>(result);
        var value = Assert.IsType<TodoItemResponse>(response.Value);
        Assert.Equal("Updated", value.Title);
    }

    [Fact]
    public async Task PutTodoItem_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var request = new UpdateTodoItemRequest
        {
            Title = "Invalid",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = false
        };

        _mockService.Setup(s => s.PutTodoItem(999, It.IsAny<TodoItemModel>())).ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.PutTodoItem(999, request);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task DeleteTodoItem_ValidId_ReturnsDeletedTodoItemResponse()
    {
        // Arrange
        var model = new TodoItemModel
        {
            Id = 1,
            Title = "To be deleted",
            DueDate = DateOnly.FromDateTime(DateTime.Today),
            IsCompleted = true
        };

        _mockService.Setup(s => s.DeleteTodoItem(1)).ReturnsAsync(model);

        // Act
        var result = await _controller.DeleteTodoItem(1);

        // Assert
        var response = Assert.IsType<ActionResult<TodoItemResponse>>(result);
        var value = Assert.IsType<TodoItemResponse>(response.Value);
        Assert.Equal(1, value.Id);
    }

    [Fact]
    public async Task DeleteTodoItem_InvalidId_ReturnsNotFound()
    {
        // Arrange
        _mockService.Setup(s => s.DeleteTodoItem(999)).ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.DeleteTodoItem(999);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}