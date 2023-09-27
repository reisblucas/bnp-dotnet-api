using backend_challenge.context;
using backend_challenge.Modules.heroSuperPower.repository;
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
        // var hero = new Hero(){ name = entity.name,  description = entity.description};
        
        // foreach (var sp in entity.Superpowers)
        // {
        //     var superpower = await _context.SuperPowers.FirstOrDefaultAsync(ctxSuper => ctxSuper.name == sp.name);
        //
        //     Console.WriteLine($"Superpower: {superpower}");
        //     _context.HeroSuperpowers.Add(new HeroSuperpower { Hero = entity, Superpower = superpower });
        // }
        //
        // var uniformColor =
        //     await _context.UniformColors.FirstOrDefaultAsync(ctxUniform => ctxUniform.name == entity.UniformColor.name);
        // hero.UniformColor.name = uniformColor.name;
        // _context.Heroes.Add(hero);
        
        // _context.SuperPowers.Add(new Superpower(){HeroSuperpowers = entity.})
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