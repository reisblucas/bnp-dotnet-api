using backend_challenge.context;
using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.update;

public class TodoUpdateUseCase
{
    private readonly ITodo _todoData;

    public TodoUpdateUseCase(TodoDbContext _databaseContext)
    {
        _todoData = new TodoData(_databaseContext);
    }

    public async Task<Todo> exec(Todo entity)
    {
        var todoUpdated = await _todoData.update(entity);

        return todoUpdated;
    }
}