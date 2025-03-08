using System.Reflection;
using FluentValidation;
using ZeroApp.Api.ActionRegistry;
using ZeroApp.Core.Contracts;

namespace ZeroApp.Api.Extensions;

public static class AutoRegisterHandlersExtensions
{
    public static void UseAutoRegisterHandlers(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddValidatorsFromAssemblies(assemblies);

        var handlerTypes = assemblies
            .SelectMany(a => a.GetTypesSafely())
            .Where(
                t => t != null && t.GetInterfaces().Any(
                    i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)
                )
            )
            .ToList();

        using var serviceProvider = services.BuildServiceProvider();

        foreach (var handlerType in handlerTypes)
        {
            if (handlerType == null)
            {
                continue;
            }

            var handlerInterface = handlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

            var requestType = handlerInterface.GetGenericArguments()[0];
            var responseType = handlerInterface.GetGenericArguments()[1];

            services.AddScoped(
                handlerInterface,
                handlerType
            );

            var handlerInstance = serviceProvider.GetService(handlerInterface);

            if (handlerInstance != null)
            {
                var actionName = handlerType.GetField("Action")?.GetValue(null)?.ToString() ?? handlerType.Name;

                typeof(ActionHandlerRegistry)
                    .GetMethod(nameof(ActionHandlerRegistry.AddHandler))
                    ?.MakeGenericMethod(
                        requestType,
                        responseType,
                        handlerInterface
                    )
                    .Invoke(
                        null,
                        new object[] { actionName, handlerInstance }
                    );
            }
        }
    }

    /// <summary>
    /// Método de extensão para evitar ReflectionTypeLoadException
    /// </summary>
    private static IEnumerable<Type?> GetTypesSafely(this Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types.Where(t => t != null);
        }
    }
}