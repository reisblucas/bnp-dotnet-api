using System.ComponentModel;
using backend_challenge.Modules.todo.repository;
using backend_challenge.Modules.todo.useCases.update;
using Microsoft.EntityFrameworkCore;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class TodoUpdateUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnUpdatedTodo_WhenCalledWithValidTodo()
    {
        // Arrange
        var testTodo = new Todo
        {
            name = "Farm",
            description = "Path of Exile",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddAsync(testTodo);
        await _dbContext.SaveChangesAsync();

        var sut = new TodoUpdateUseCase(_dbContext);

        // Modificar a entidade
        testTodo.name = "Farm";
        testTodo.description = "Path of Exile";

        // Act
        var result = await sut.exec(testTodo);

        // Assert
        Assert.Equal(testTodo.id, result.id);
        Assert.Equal(testTodo.name, result.name);
        Assert.Equal(testTodo.description, result.description);
    }
    
    [Fact]
    public async Task Exec_ShouldReturnUpdatedTodo_DifferentValidValue()
    {
        // Arrange
        var prevTodo = new Todo()
        {
            name = "Farm",
            description = "Path of Exile",
        };
        var testTodo = new Todo
        {
            name = "Farm",
            description = "Chimeric",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddAsync(testTodo);
        await _dbContext.SaveChangesAsync();

        var useCase = new TodoUpdateUseCase(_dbContext);
        
        // Modificar a entidade
        testTodo.name = "Dark";
        testTodo.description = "Souls";

        // Act
        var result = await useCase.exec(testTodo);

        // Assert
        Assert.Equal(testTodo.id, result.id);
        Assert.NotEqual(prevTodo.name, result.name);
        Assert.NotEqual(prevTodo.description, result.description);
    }
    
    [Fact]
    public async Task Throw_UpdateWithoutName()
    {
        // Arrange
        var itemOnDb = new Todo
        {
            name = "Farm",
            description = "Path of Exile",
        };
        
        var request = new Todo()
        {
            id = itemOnDb.id,
            name = null!,
            description = "Task to do",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        await _dbContext.Todo.AddAsync(itemOnDb);
        var usecase = new TodoUpdateUseCase(_dbContext);

        // Act and Assert
        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => usecase.exec(request));
        Assert.Contains("Required properties '{'name'}' are missing for the instance of entity type 'Todo'", exception.Message);
    }
    
    [Fact]
    [Description("Test task without description")]
    public async Task Throw_UpdateWithoutDescription()
    {
        // Arrange
        var itemOnDb = new Todo
        {
            name = "Farm",
            description = "Path of Exile",
        };
        
        var request = new Todo()
        {
            id = itemOnDb.id,
            name = "Taskzada",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        await _dbContext.Todo.AddAsync(itemOnDb);
        var usecase = new TodoUpdateUseCase(_dbContext);

        // Act and Assert
        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => usecase.exec(request));
        Assert.Contains("Required properties '{'description'}' are missing for the instance of entity type 'Todo'", exception.Message);
    }
    
    [Fact]
    [Description("Test task without description")]
    public async Task Throw_UpdateWithoutNameAndDescription()
    {
        var testTodo = new Todo()
        {
            id = Guid.NewGuid(),
        };
        
        var itemOnDb = new Todo
        {
            name = "Farm",
            description = "Path of Exile",
        };
        
        var request = new Todo()
        {
            id = itemOnDb.id,
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        await _dbContext.Todo.AddAsync(itemOnDb);
        var usecase = new TodoUpdateUseCase(_dbContext);

        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => usecase.exec(request));
        Assert.Contains("Required properties '{'description', 'name'}' are missing for the instance of entity type 'Todo'", exception.Message);
    }
    
    [Fact]
    [Description("Test task without description")]
    public async Task Throw_UpdateInexistentEntity()
    {
        var testTodo = new Todo()
        {
            id = Guid.NewGuid(),
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();
        var usecase = new TodoUpdateUseCase(_dbContext);

        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException>(() => usecase.exec(testTodo));
        Assert.Contains("Attempted to update or delete an entity that does not exist in the store.", exception.Message);
    }
}