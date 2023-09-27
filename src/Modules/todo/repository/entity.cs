namespace backend_challenge.Modules.todo.repository;

public class Todo
{
    public Guid id { get; set; }
    public String name { get; set; } = null!;
    public String description { get; set; } = null!;
    public TodoStatus todoStatus { get; set; } = TodoStatus.Pending;
    public DateTime createdAt { get; set; } = DateTime.Now;
    public DateTime? completedAt { get; set; } = null;
}