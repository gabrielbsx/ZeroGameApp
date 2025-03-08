using FluentValidation;
using MediatR;
using ZeroApp.Api.Behaviors;
using ZeroApp.Api.Middlewares;
using ZeroApp.Core.Features.Commands.CreateCharacter;
using ZeroApp.Core.Features.Commands.RegisterUser;

namespace ZeroApp.Api.Extensions;

public static class ZeroAppExtensions
{
    public static void UseZeroApp(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
        services.AddValidatorsFromAssemblies(assemblies);
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IRequestHandler<RegisterUserRequest, RegisterUserResponse>, RegisterUserCommand>();
        services.AddScoped<IRequestHandler<CreateCharacterRequest, CreateCharacterResponse>, CreateCharacterCommand>();
    }

    public static void Configure(this IApplicationBuilder app)
    {
        app.UseMiddleware<ActionValidationMiddleware>();
        app.UseMiddleware<ErrorBoundaryMiddleware>();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}