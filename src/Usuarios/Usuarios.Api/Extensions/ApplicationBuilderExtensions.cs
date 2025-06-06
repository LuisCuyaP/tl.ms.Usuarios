using Microsoft.EntityFrameworkCore;
using Usuarios.Api.Middleware;
using Usuarios.Infraestructure;

namespace Usuarios.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async void ApplyMigrations(
        this IApplicationBuilder app
    )
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error en la migracion de dominio a la base de datos");
                throw;
            }
        }
    }

    public static void UseCustomExceptionHandler(
        this IApplicationBuilder app
    )
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}