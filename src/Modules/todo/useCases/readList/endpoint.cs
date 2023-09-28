using backend_challenge.context;
using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.readList;

public class TodoReadListEndpoint : EndpointWithoutRequest<List<Todo>>
{
    public TodoDbContext _DbContext { get; init; }

    public override void Configure()
    {
        Get("todos");
        Summary(s =>
        {
            s.Summary = "List \"Todos\"";
            s.Description = "Get the todos list";
        });
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var useCase = new TodoReadListUseCase(_DbContext);
            var createdTodo = await useCase.exec();

            await SendAsync(createdTodo);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}