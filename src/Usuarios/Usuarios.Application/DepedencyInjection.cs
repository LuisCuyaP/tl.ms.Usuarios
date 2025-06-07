using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Usuarios.Application.Abstractions.Behaviors;
using Usuarios.Domain.Usuarios;

namespace Usuarios.Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DepedencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            }

        );

        services.AddTransient<NombreUsuarioService>(); // servicios ligeros  -- scoped (para http)
        services.AddValidatorsFromAssembly(typeof(DepedencyInjection).Assembly);
        return services;
    }

}