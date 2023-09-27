using backend_challenge.Modules.hero.repository;
using backend_challenge.Modules.superpower.repository;

namespace backend_challenge.Modules.hero.useCases.create;

public class Mapper : Mapper<Request, Response, Hero>
{
    public override Hero ToEntity(Request entity)
    {
        var hero = new Hero
        {
            name = entity.name,
            description = entity.description,
            image = entity.image
        };

        var superpowers = entity.Superpowers.Select(sp => new Superpower { name = sp.name }).ToList();
        hero.Superpowers = superpowers;

        hero.UniformColor = entity.UniformColor;

        return hero;
    }

    public override Response FromEntity(Hero entity) => new()
    {
        id = entity.id,
        name = entity.name,
        description = entity.description,
        image = entity.image
    };
}