using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.create;

public class Mapper : Mapper<Request, Response, Todo>
{
    public override Todo ToEntity(Request req) => new()
    {
        name = req.name,
        description = req.description
    };

    public override Response FromEntity(Todo entity) => new()
    {
        id = entity.id,
        name = entity.name,
        description = entity.description,
        todoStatus = entity.todoStatus,
        createdAt = entity.createdAt,
        completedAt = entity.completedAt
    };
}