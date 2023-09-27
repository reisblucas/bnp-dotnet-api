namespace backend_challenge.Modules.todo.useCases.update;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.id)
            .NotEmpty()
            .WithMessage("Property \"id\" is required!");

        RuleFor(req => req.name)
            .NotEmpty()
            .WithMessage("Property \"name\" is required!");
        
        RuleFor(req => req.description)
            .NotEmpty()
            .WithMessage("Property \"description\" is required");
    }
}