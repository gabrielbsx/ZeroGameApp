using FluentValidation;

namespace ZeroApp.Core.Features.Queries.CheckUserEmail;

public class CheckUserEmailValidation : AbstractValidator<CheckUserEmailRequest>
{
    public CheckUserEmailValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid");
    }
}