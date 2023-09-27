using System.Text.Json.Serialization;
using backend_challenge.Modules.superpower.repository;
using backend_challenge.Modules.uniformColor.repository;

namespace backend_challenge.Modules.hero.useCases.create;

public class Request
{
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public string? image { get; set; }
    [JsonPropertyName("superpowers")]
    public List<Superpower> Superpowers { get; set; } = new();
    [JsonPropertyName("uniformColor")]
    public UniformColor UniformColor { get; set; } = null!;
}