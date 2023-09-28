using backend_challenge.Modules.todo.repository;

namespace backend_challenge.context;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {}
    
    public DbSet<Todo>? Todo { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
    }
}