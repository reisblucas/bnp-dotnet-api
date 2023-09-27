using backend_challenge.Modules.hero.repository;
using backend_challenge.Modules.superpower.repository;

namespace backend_challenge.Modules.heroSuperPower.repository;

public class HeroSuperpower
{
    public Guid HeroId { get; set; }
    public Hero Hero { get; set; }
    public Guid SuperpowerId { get; set; }
    public Superpower Superpower { get; set; }
}