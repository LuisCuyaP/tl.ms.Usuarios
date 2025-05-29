using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public record NombreUsuario
{
    public string Value { get; init; }

    private NombreUsuario(string value)
    {
        Value = value;
    }
    public static Result<NombreUsuario> Create(string nombreUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario))
        {
            return Result.Failure<NombreUsuario>(UsuarioErrores.NombreUsuarioInvalido);
        }
        return new NombreUsuario(nombreUsuario);
    }
}
