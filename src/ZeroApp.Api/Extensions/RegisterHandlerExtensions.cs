using FluentValidation;
using ZeroApp.Api.Handlers;
using ZeroApp.Core.Contracts;
using ZeroApp.Core.Features.RegisterUserFeature;

namespace ZeroApp.Api.Extensions;

public static class RegisterHandlerExtensions
{
    public static void UseRegisterHandler(this IServiceCollection services)
    {
        // Registrar Validators
        services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserValidation>();

        // Registrar Handlers
        services.AddScoped<IRequestHandler<RegisterUserRequest, RegisterUserResponse>, RegisterUserCommand>();

        // Registrar ActionHandlerRegistry
        var serviceProvider = services.BuildServiceProvider();
        var registerUserValidator = serviceProvider.GetRequiredService<IValidator<RegisterUserRequest>>();
        var registerUserHandler =
            serviceProvider.GetRequiredService<IRequestHandler<RegisterUserRequest, RegisterUserResponse>>();

        // Adicionar Handlers

        // RegisterUser
        ActionHandlerRegistry
            .AddHandler<RegisterUserRequest, RegisterUserResponse,
                IRequestHandler<RegisterUserRequest, RegisterUserResponse>>(
                registerUserValidator,
                registerUserHandler
            );
    }
}