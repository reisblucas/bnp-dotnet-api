namespace backend_challenge.Modules.hero.useCases.create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(request => request.name)
            .NotEmpty()
            .WithMessage("Parameter \"name\" is required!");

        RuleFor(req => req.description)
            .NotEmpty()
            .WithMessage("Parameter \"description\" is required");
    }
}
