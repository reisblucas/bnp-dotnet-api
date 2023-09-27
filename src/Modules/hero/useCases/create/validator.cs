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

        RuleFor(req => req.Superpowers)
            .NotEmpty()
            .WithMessage("Parameter \"superpowers\" is required");
        
        RuleFor(req => req.UniformColor)
            .NotEmpty()
            .WithMessage("Parameter \"uniformColor\" is required");
    }
}
