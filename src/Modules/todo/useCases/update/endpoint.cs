using backend_challenge.context;
using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.update;

public class TodoUpdateEndPoint : Endpoint<Request, Response, Mapper>
{
    public TodoDbContext _dbContext { get; init; }

    public override void Configure()
    {
        Put("todos");
        Summary(s =>
        {
            s.Summary = "Update one todo";
            s.Description = "Update the whole object with all the provided parameters.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var updateData = Map.ToEntity(req);

            var useCase = new TodoUpdateUseCase(_dbContext);

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