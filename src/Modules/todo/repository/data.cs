using backend_challenge.context;

namespace backend_challenge.Modules.todo.repository;

public class TodoData : ITodo
{
    private readonly AppDbContext _dbContext;
    
    public TodoData(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<Todo> create(Todo entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Todo?> readOne(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Todo>> readList()
    {
        throw new NotImplementedException();
    }

    public async Task<Todo> update(Todo entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> delete(Guid id)
    {
        throw new NotImplementedException();
    }
}