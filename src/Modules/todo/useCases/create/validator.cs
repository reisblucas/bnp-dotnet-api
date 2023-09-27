namespace backend_challenge.Modules.todo.useCases.create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.name)
            .NotEmpty()
            .WithMessage("Property \"name\" is required!");

        RuleFor(req => req.description)
            .NotEmpty()
            .WithMessage("Property \"description\" is required");
    }
}