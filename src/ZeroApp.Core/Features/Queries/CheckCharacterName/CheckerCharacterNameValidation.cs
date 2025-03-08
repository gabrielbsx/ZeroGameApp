using FluentValidation;

namespace ZeroApp.Core.Features.Queries.CheckCharacterName;

public class CheckerCharacterNameValidation : AbstractValidator<CheckCharacterNameRequest>
{
    public CheckerCharacterNameValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}