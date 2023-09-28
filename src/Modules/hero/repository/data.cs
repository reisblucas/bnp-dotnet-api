using backend_challenge.context;
using backend_challenge.Modules.superpower.repository;

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
        var uniform = await _context.UniformColors.SingleOrDefaultAsync(u => u.name == entity.UniformColor.name);

        if (uniform != null)
        {
            _context.Entry(uniform).State = EntityState.Detached;
        }

        var superpowerQuery = new List<Superpower>();
        foreach (var super in entity.Superpowers)
        {
            var query = await _context.SuperPowers.FirstOrDefaultAsync(sp => sp.name == super.name);
            
            if (query != null)
            {
                // Console.WriteLine($"Superpower query: {query.id} {query.name}");
                _context.Entry(query).State = EntityState.Detached;
                superpowerQuery.Add(query);
            }
        
        }
        
        if (uniform != null)
        {
            _context.Entry(uniform).State = EntityState.Detached;
        }

        entity.UniformColor.id = uniform.id;
        entity.Superpowers = superpowerQuery.ToList();
        
        // Console.WriteLine($"Data > Uniform {uniform.id} {uniform.name}");

        _context.Heroes.Add(entity);

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