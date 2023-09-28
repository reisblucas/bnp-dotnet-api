using backend_challenge.Modules.todo.repository;
using backend_challenge.Modules.todo.useCases.delete;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class TodoDeleteUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldDeleteTodo_WhenCalledWithValidId()
    {
        // Arrange
        var testTodo = new Todo
        {
            id = Guid.NewGuid(),
            name = "Be Superman",
            description = "thumbs up",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddAsync(testTodo);
        await _dbContext.SaveChangesAsync();

        var useCase = new TodoDeleteUseCase(_dbContext);

        // Act
        var result = await useCase.exec(testTodo.id);

        // Assert
        Assert.Equal(1, result);
        Assert.DoesNotContain(testTodo, _dbContext.Todo);
    }

    [Fact]
    public async Task Exec_ShouldNotDeleteAnyTodo_WhenCalledWithInvalidId()
    {
        // Arrange
        var testTodo = new Todo()
        {
            id = Guid.NewGuid(),
            name = "Supa",
            description = "Man",
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddAsync(testTodo);
        await _dbContext.SaveChangesAsync();

        var useCase = new TodoDeleteUseCase(_dbContext);

        var invalidId = Guid.NewGuid();

        // Act
        var result = await useCase.exec(invalidId);

        // Assert
        Assert.Equal(0, result);
        Assert.Contains(testTodo, _dbContext.Todo);
    }
}