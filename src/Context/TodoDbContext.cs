using backend_challenge.Modules.todo.repository;

namespace backend_challenge.context;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {}
    
    public DbSet<Todo>? Todo { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // #region Hero
        // mb.Entity<Hero>()
        //     .HasKey(hero => hero.id);
        //
        // mb.Entity<Hero>()
        //     .Property(hero => hero.name)
        //     .IsRequired();
        // #endregion
    }
}