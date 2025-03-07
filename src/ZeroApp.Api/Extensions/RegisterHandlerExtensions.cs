using FluentValidation;
using ZeroApp.Api.Handlers;
using ZeroApp.Core.Contracts;
using ZeroApp.Core.Features.RegisterUserFeature;

namespace ZeroApp.Api.Extensions;

public static class RegisterHandlerExtensions
{
    public static void UseRegisterHandler(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterUserValidation>();

        // Registrar Validators
        services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserValidation>();

        // Registrar Handlers
        services.AddScoped<IRequestHandler<RegisterUserRequest, RegisterUserResponse>, RegisterUserCommand>();

        // RegisterUser
        var registerUserValidator = services.BuildServiceProvider().GetRequiredService<IValidator<RegisterUserRequest>>();
        var registerUserHandler = services.BuildServiceProvider().GetRequiredService<IRequestHandler<RegisterUserRequest, RegisterUserResponse>>();
        ActionHandlerRegistry
            .AddHandler<RegisterUserRequest, RegisterUserResponse,
                IRequestHandler<RegisterUserRequest, RegisterUserResponse>>(
                "registerUser",
                registerUserValidator,
                registerUserHandler
            );
    }
}