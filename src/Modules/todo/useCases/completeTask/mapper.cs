using backend_challenge.Modules.todo.repository;

namespace backend_challenge.Modules.todo.useCases.completeTask;

public class Mapper : Mapper<Request, Response, Todo>
{
    public override Todo ToEntity(Request req) => new()
    {
        id = req.id, 
        completedAt = req.completedAt
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