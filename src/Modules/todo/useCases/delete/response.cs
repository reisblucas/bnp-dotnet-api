namespace backend_challenge.Modules.todo.useCases.delete;

public class Response
{
    public Guid id { get; set; }
    public string Message => "\"Todo\" deleted";
}