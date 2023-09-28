using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.completeTask;

public class Response : Todo
{
    public Guid id { get; set; }
    public string Message => "\"Todo\" updated";
}