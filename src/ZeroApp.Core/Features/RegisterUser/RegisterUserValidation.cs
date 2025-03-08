using FluentValidation;

namespace ZeroApp.Core.Features.RegisterUser;

public class RegisterUserValidation : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");
        RuleFor(x => x.RegistrationSource).NotEmpty().WithMessage("Registration source is required.");
        RuleFor(x => x.RegistrationIp).NotEmpty().WithMessage("Registration IP is required.");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required.");
    }
}