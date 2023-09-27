namespace backend_challenge.Modules.todo.repository;

public class Todo
{
    public Guid id { get; set; }
    public String name { get; set; }
    public String description { get; set; }
    public TodoStatus todoStatus { get; set; }
}