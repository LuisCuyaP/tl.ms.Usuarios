using Microsoft.Extensions.DependencyInjection;
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
            }

        );

        services.AddTransient<NombreUsuarioService>(); // servicios ligeros  -- scoped (para http)
        return services;
    }

}