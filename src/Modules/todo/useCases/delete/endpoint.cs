using backend_challenge.context;

namespace backend_challenge.Modules.todo.useCases.delete;

public class TodoDeleteEndpoint : Endpoint<Request, Response>
{
    public TodoDbContext _dbContext { get; set; }

    public override void Configure()
    {
        Delete("todo");
        Summary(s =>
        {
            s.Summary = "Removes a \"Todo\"";
            s.Description = "This will delete the \"Todo\"";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var useCase = new TodoDeleteUseCase(_dbContext);

            int deletedRow = await useCase.exec(req.id);

            if (deletedRow == 0)
            {
                await SendNotFoundAsync();
                return;
            }

            Response.id = req.id;

            await SendAsync(Response);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}