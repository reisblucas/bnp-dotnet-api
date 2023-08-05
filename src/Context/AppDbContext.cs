using backend_challenge.Modules.hero.repository;

namespace backend_challenge.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Hero>? Heroes { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Hero>()
            .HasKey(hero => hero.id);
        
        mb.Entity<Hero>()
            .Property(hero => hero.name)
            .IsRequired();
    }
}