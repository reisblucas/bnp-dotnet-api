using backend_challenge.Modules.heroSuperPower.repository;

namespace backend_challenge.Modules.superpower.repository;

public class Superpower
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public virtual List<HeroSuperpower> HeroSuperpowers { get; set; }
}
