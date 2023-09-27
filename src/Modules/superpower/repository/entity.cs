using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.superpower.repository;

public class Superpower
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public virtual List<Hero> Heroes { get; set; } = new();
}
