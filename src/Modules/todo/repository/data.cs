using backend_challenge.context;

namespace backend_challenge.Modules.todo.repository;

public class TodoData : ITodo
{
    private readonly TodoDbContext _dbContext;
    
    public TodoData(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Todo> create(Todo entity)
    {
        _dbContext.Todo.Add(entity);

        var ret = await _dbContext.SaveChangesAsync();
        
        Console.WriteLine(ret);
        return entity;
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