using backend_challenge.context;

namespace backend_challenge.Modules.todo.repository;

public class TodoCreateUseCase
{
    private readonly ITodo _todoData;

    public TodoCreateUseCase(TodoDbContext _dbContext)
    {
        _todoData = new TodoData(_dbContext);
    }

    public async Task<Todo> exec(Todo entity)
    {
        var createdTodo = await _todoData.create(entity);

        return createdTodo;
    }
}