using backend_challenge.Modules.hero.repository;
using backend_challenge.Modules.superpower.repository;
using backend_challenge.Modules.uniformColor.repository;

namespace backend_challenge.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Hero>? Heroes { get; set; }
    public DbSet<Superpower>? SuperPowers { get; set; }
    public DbSet<UniformColor>? UniformColors { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        #region Hero

        mb.Entity<Hero>()
            .HasKey(hero => hero.id);

        mb.Entity<Hero>()
            .Property(hero => hero.name)
            .IsRequired();

        #endregion

        #region Superpower

        mb.Entity<Superpower>()
            .HasKey(superpower => superpower.id);

        mb.Entity<Superpower>()
            .HasData(
                new Superpower { id = Guid.NewGuid(), name = "Super Strength" },
                new Superpower { id = Guid.NewGuid(), name = "Super Speed" },
                new Superpower { id = Guid.NewGuid(), name = "Flight" },
                new Superpower { id = Guid.NewGuid(), name = "Teleportation" },
                new Superpower { id = Guid.NewGuid(), name = "Telekinesis" },
                new Superpower { id = Guid.NewGuid(), name = "Mind Control" },
                new Superpower { id = Guid.NewGuid(), name = "Invisibility" },
                new Superpower { id = Guid.NewGuid(), name = "Healing" }
            );

        #endregion

        #region UniformColor

        mb.Entity<UniformColor>()
            .HasKey(uniformColor => uniformColor.id);

        mb.Entity<UniformColor>()
            .HasData(
                new UniformColor { id = Guid.NewGuid(), name = "Red" },
                new UniformColor { id = Guid.NewGuid(), name = "Blue" },
                new UniformColor { id = Guid.NewGuid(), name = "Green" },
                new UniformColor { id = Guid.NewGuid(), name = "Yellow" },
                new UniformColor { id = Guid.NewGuid(), name = "Orange" },
                new UniformColor { id = Guid.NewGuid(), name = "Purple" },
                new UniformColor { id = Guid.NewGuid(), name = "Black" },
                new UniformColor { id = Guid.NewGuid(), name = "White" }
            );

        #endregion

        // #region Relations

        mb.Entity<Hero>()
            .HasMany(h => h.Superpowers)
            .WithMany(sp => sp.Heroes)
            .UsingEntity(j => j.ToTable("HeroSuperpowers"));

        mb.Entity<Hero>()
            .HasOne(u => u.UniformColor)
            .WithOne(u => u.Hero)
            .HasForeignKey<UniformColor>(u => u.id)
            .OnDelete(DeleteBehavior.Restrict);

        // #endregion
    }
}