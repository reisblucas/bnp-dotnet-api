using backend_challenge.context;
using Namotion.Reflection;

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
        var query = _dbContext.Todo;
        return await query.ToListAsync();
    }

    public async Task<Todo> update(Todo entity)
    {
        _dbContext.Todo.Update(entity);
        _ = await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> delete(Guid id)
    {
        var todo = await _dbContext.Todo.FindAsync(id);

        if (todo is null) return 0;

        _dbContext.Todo.Remove(todo);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Todo> completeTask(Todo entity)
    {
        _dbContext.Database.EnsureCreated();
        var prevTodoTask = await _dbContext.Todo.SingleOrDefaultAsync(td => td.id == entity.id);
        
        // check if local is not null 
        if (prevTodoTask != null)
        {
            // detach -> this saves my day and I can complete the another challeng
            _dbContext.Entry(prevTodoTask).State = EntityState.Detached;
        }
        
        entity.name = prevTodoTask.name;
        entity.description = prevTodoTask.description;
        entity.createdAt = prevTodoTask.createdAt;
        entity.todoStatus = TodoStatus.Completed.ToString();
        
        _dbContext.Todo.Update(entity);
        _ = await _dbContext.SaveChangesAsync();
        return entity;
    }
}