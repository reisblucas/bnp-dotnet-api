using backend_challenge.Modules.hero.useCases.readList;
using backend_challenge.Modules.hero.repository;
using backend_challenge.Modules.todo.repository;
using backend_challenge.Modules.todo.useCases.readList;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class TodoReadListUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnListOfTodos_WhenCalled()
    {
        // Arrange
        var testTodos = new List<Todo>
        {
            new Todo
            {
                id = Guid.NewGuid(),
                name = "End challenge",
                description = "Test",
            },
            new Todo
            {
                id = Guid.NewGuid(),
                name = "Farm Path of Exile",
                description = "Explosive Arrow Elementalist",
            },
        };

        await using var _dbContext = new MockTodoDb().CreateDbContext();

        await _dbContext.Todo.AddRangeAsync(testTodos);
        await _dbContext.SaveChangesAsync();

        var useCase = new TodoReadListUseCase(_dbContext);

        // Act
        var result = await useCase.exec();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(testTodos.Count, result.Count);

        Assert.Collection(result,
            hero => 
            {
                Assert.Equal(testTodos[0].name, hero.name);
                Assert.Equal(testTodos[0].description, hero.description);
            },
            hero => 
            {
                Assert.Equal(testTodos[1].name, hero.name);
                Assert.Equal(testTodos[1].description, hero.description);
            }
        );
    }
}