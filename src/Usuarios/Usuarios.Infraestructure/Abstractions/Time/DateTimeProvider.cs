using Usuarios.Application.Abstractions.Time;

namespace Usuarios.Infraestructure.Abstractions.Time;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}