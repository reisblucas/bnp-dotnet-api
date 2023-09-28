namespace backend_challenge.Modules.todo.useCases.delete;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.id)
            .NotEmpty()
            .WithMessage("Property \"id\" is required!!");
    }
}