using backend_challenge.context;
using backend_challenge.Modules.todo.repository;
using backend_challenge.Modules.todo.useCases.update;

namespace backend_challenge.Modules.todo.useCases.completeTask;

public class TodoCompleteTaskEndpoint : Endpoint<Request, Response, Mapper>
{
    public TodoDbContext _DbContext { get; init; }

    public override void Configure()
    {
        Patch("todo/completeTask");
        Summary(s =>
        {
            s.Summary = "Complete task";
            s.Description = "Update \"completedAt\" field";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var updateData = Map.ToEntity(req);

            var useCase = new TodoCompleteTaskUseCase(_DbContext);

            Todo updatedTodo;
            try
            {
                updatedTodo = await useCase.exec(updateData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nDB Exception: {e.Message}\n");
                await SendNotFoundAsync(ct);
                return;
            }
            
            var response = Map.FromEntity(updatedTodo);

            await SendAsync(response);
        }
        catch (System.Exception e)
        {
            ThrowError(e.Message);
        }
    }
}