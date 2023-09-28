using System.ComponentModel;
using System.Data.Common;
using backend_challenge.Modules.todo.repository;
using backend_challenge.Modules.todo.useCases.completeTask;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class TodoCompleteTaskUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnCompletedTodo_WhenCalledWithValidTodo()
    {
        // Arrange
        var prevDbValue = new Todo()
        {
            name = "Farm",
            description = "Path of Exile",
        };
        Assert.Equal("Pending", prevDbValue.todoStatus);
        
        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddAsync(prevDbValue);
        await _dbContext.SaveChangesAsync();

        // Act
        var useCase = new TodoCompleteTaskUseCase(_dbContext);
        var result = await useCase.exec(prevDbValue);

        // Assert
        Assert.Equal(prevDbValue.id, result.id);
        Assert.Equal("Completed", prevDbValue.todoStatus);
    }
    
    [Fact]
    public async Task Throw_TryToCompleteInexistentTask()
    {
        // Arrange
        var prevDbValue = new Todo()
        {
            name = "Farm",
            description = "Path of Exile",
        };
        Assert.Equal("Pending", prevDbValue.todoStatus);
        
        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddAsync(prevDbValue);
        await _dbContext.SaveChangesAsync();

        // Act
        var useCase = new TodoCompleteTaskUseCase(_dbContext);

        var inexistentId = new Todo();

        // Assert
        var exception = await Assert.ThrowsAsync<NullReferenceException>(() => useCase.exec(inexistentId));
        Assert.Contains("Object reference not set to an instance of an object", exception.Message);
    }
}