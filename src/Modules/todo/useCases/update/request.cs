namespace backend_challenge.Modules.todo.useCases.update;

public class Request
{
    public Guid id { get; set;  }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
}