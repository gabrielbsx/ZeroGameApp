using FluentValidation;
using ZeroApp.Api.ActionRegistry;
using ZeroApp.Core.Contracts;
using ZeroApp.Core.Features.CreateCharacter;
using ZeroApp.Core.Features.RegisterUser;

namespace ZeroApp.Api.Extensions;

public static class RegisterHandlerExtensions
{
    public static void UseRegisterHandler(this IServiceCollection services)
    {
        // Registrar Validators
        services.AddValidatorsFromAssemblyContaining<RegisterUserValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateCharacterValidation>();

        // Registrar Handlers
        services.AddScoped<IRequestHandler<RegisterUserRequest, RegisterUserResponse>, RegisterUserCommand>();
        services.AddScoped<IRequestHandler<CreateCharacterRequest, CreateCharacterResponse>, CreateCharacterCommand>();
    }
}