using backend_challenge.context;
using backend_challenge.Modules.superpower.repository;
using backend_challenge.Modules.uniformColor.repository;

namespace backend_challenge.Modules.hero.repository;

public class HeroData : IHero
{
    private readonly AppDbContext _context;

    public HeroData(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Hero> create(Hero entity)
    {
        _context.Database.EnsureCreated();
        
        var uniformColor = await _context.UniformColors
            .FirstOrDefaultAsync(uc => uc.name == entity.UniformColor.name);

        if (uniformColor == null)
        {
            throw new ArgumentException($"UniformColor '{entity.UniformColor.name}' not found.");
        }

        var superpowers = await _context.SuperPowers
            .Where(sp => entity.Superpowers.Select(s => s.name).Contains(sp.name))
            .ToListAsync();
        
        // @unsolved
        // "The property 'UniformColor.id' is part of a key and so cannot be modified or marked as modified.
        //  To change the principal of an existing entity with an identifying foreign key, first delete the dependent and invoke 'SaveChanges',
        //  and then associate the dependent with the new principal."
        var hero = new Hero
        {
            name = entity.name,
            description = entity.description,
            image = entity.image,
            Superpowers = superpowers,
            UniformColor = uniformColor
        };

        // cannot insert the new hero with association bbecause of UniformColor
        _context.Heroes.Add(hero);

        var ret = await _context.SaveChangesAsync();

        Console.WriteLine(ret);

        return entity;
    }

    public async Task<List<Hero>> readList()
    {
        var query = _context.Heroes;

        return await query.ToListAsync();
    }


    public async Task<Hero?> readOne(Guid id)
    {
        var hero = await _context.Heroes.FindAsync(id);

        return hero;
    }

    public async Task<Hero> update(Hero entity)
    {
        _context.Heroes.Update(entity);

        _ = await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<int> delete(Guid id)
    {
        var hero = await _context.Heroes.FindAsync(id);

        if (hero is null) return 0;

        _context.Heroes.Remove(hero);

        return await _context.SaveChangesAsync();
    }
}