namespace backend_challenge.Modules.todo.useCases.completeTask;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.id)
            .NotEmpty()
            .WithMessage("Property \"id\" is required!");
    }
}