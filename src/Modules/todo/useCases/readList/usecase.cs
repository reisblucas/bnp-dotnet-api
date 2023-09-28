using backend_challenge.context;
using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.readList;

public class TodoReadListUseCase
{
    private readonly ITodo _data;

    public TodoReadListUseCase(TodoDbContext _context)
    {
        _data = new TodoData(_context);
    }

    public async Task<List<Todo>> exec()
    {
        return await _data.readList();
    }
}