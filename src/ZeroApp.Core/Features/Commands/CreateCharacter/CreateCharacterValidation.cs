using FluentValidation;

namespace ZeroApp.Core.Features.Commands.CreateCharacter;

public class CreateCharacterValidation : AbstractValidator<CreateCharacterRequest>
{
    public CreateCharacterValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must be at most 100 characters");
    }
}