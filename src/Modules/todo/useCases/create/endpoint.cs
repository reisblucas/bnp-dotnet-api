using backend_challenge.context;
using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.create;

public class TodoCreateOneEndpoint : Endpoint<Request, Response, Mapper>
{
    public TodoDbContext _DbContext { get; init; }

    public override void Configure()
    {
        Post("todo");
        Summary(s =>
        {
            s.Summary = "Creates a new \"Todo\"";
            s.Description = "Register a \"Todo\"";
        });
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var useCase = new TodoCreateUseCase(_DbContext);

            var newTodo = Map.ToEntity(req);

            var createdTodo = await useCase.exec(newTodo);

            var responseTodo = Map.FromEntity(createdTodo);

            await SendAsync(responseTodo);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}