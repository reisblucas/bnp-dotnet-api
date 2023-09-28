namespace backend_challenge.Modules.todo.repository;

public class Todo
{
    public Guid id { get; set; }
    public String name { get; set; } = null!;
    public String description { get; set; } = null!;
    public string todoStatus { get; set; } = TodoStatus.Pending.ToString();
    public DateTime createdAt { get; set; }
    public DateTime? completedAt { get; set; } = null;
}