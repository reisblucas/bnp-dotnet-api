using System.ComponentModel;
using backend_challenge.Modules.todo.repository;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class TodoCreateUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnCreatedTodo_WhenCalledWithValidTodo()
    {
        var testTodo = new Todo
        {
            id = Guid.NewGuid(),
            name = "Test",
            description = "Terminar unit test",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        var usecase = new TodoCreateUseCase(_dbContext);

        var result = await usecase.exec(testTodo);

        Assert.Equal(testTodo.id, result.id);
        Assert.Equal(testTodo.name, result.name);
        Assert.Equal(testTodo.description, result.description);
        Assert.Equal(testTodo.todoStatus, result.todoStatus);
        Assert.Equal(testTodo.createdAt, result.createdAt);
        Assert.Equal(testTodo.completedAt, result.completedAt);
    }

    [Fact]
    public async Task Exec_ShouldThrowException_WhenCalledWithInvalidTodo()
    {
        // Arrange
        var testTodo = new Todo()
        {
            id = Guid.NewGuid(),
            name = null!,
            description = "Task to do",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        var usecase = new TodoCreateUseCase(_dbContext);

        // Act and Assert
        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => usecase.exec(testTodo));
        Assert.Contains("Required properties '{'name'}' are missing for the instance of entity type 'Todo'", exception.Message);
    }
    
    [Fact]
    [Description("Test task without description")]
    public async Task TodoWithoutDescription_Throw()
    {
        var testTodo = new Todo()
        {
            id = Guid.NewGuid(),
            name = "Task",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        var usecase = new TodoCreateUseCase(_dbContext);

        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => usecase.exec(testTodo));
        Assert.Contains("Required properties '{'description'}' are missing for the instance of entity type 'Todo'", exception.Message);
    }
    
    [Fact]
    [Description("Test task without description")]
    public async Task TodoWithouNameAndDescription()
    {
        var testTodo = new Todo()
        {
            id = Guid.NewGuid(),
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        var usecase = new TodoCreateUseCase(_dbContext);

        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => usecase.exec(testTodo));
        Assert.Contains("Required properties '{'description', 'name'}' are missing for the instance of entity type 'Todo'", exception.Message);
    }
}