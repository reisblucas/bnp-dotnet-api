namespace backend_challenge.Modules.todo.useCases.completeTask;

public class Request
{
    public Guid id { get; set;  }
    public DateTime completedAt { get; set; } = DateTime.Now;
}