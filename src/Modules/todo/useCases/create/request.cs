using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.create;

public class Request
{
    public String name { get; set; } = null!;
    public String description { get; set; } = null!;
}