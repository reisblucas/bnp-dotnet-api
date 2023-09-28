using backend_challenge.context;
using backend_challenge.Modules.hero.repository;
using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.delete;

public class TodoDeleteUseCase
{
    private readonly ITodo _heroData;

    public TodoDeleteUseCase(TodoDbContext _databaseContext)
    {
        _heroData = new TodoData(_databaseContext);
    }

    public async Task<int> exec(Guid id)
    {
        return await _heroData.delete(id);
    }
}
