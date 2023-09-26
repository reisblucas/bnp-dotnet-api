using backend_challenge.context;
using backend_challenge.Modules.hero.repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend_challenge.Modules.hero.useCases.update;

public class HeroUpdateEndPoint : Endpoint<Request, Response, Mapper>
{
    public AppDbContext _dbContext { get; init; }

    public override void Configure()
    {
        Put("heroes");
        Summary(s =>
        {
            s.Summary = "Update the hero";
            s.Description = "Update the whole object with all the provided parameters.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var updateData = Map.ToEntity(req);

            var useCase = new HeroUpdateUseCase(_dbContext);

            Hero updatedHero;
            try
            {
                updatedHero = await useCase.exec(updateData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nDB Exception: {e.Message}\n");
                await SendNotFoundAsync(ct);
                return;
            }
            
            var response = Map.FromEntity(updatedHero);

            await SendAsync(response);
        }
        catch (System.Exception e)
        {
            ThrowError(e.Message);
        }
    }
}