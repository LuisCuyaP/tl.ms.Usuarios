using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;
public record Password
{
    public string Value { get; init; }
    private Password(string value)
    {
        Value = value;
    }
    public static Result<Password> Create(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
        {
            return Result.Failure<Password>(UsuarioErrores.PasswordInvalido);
        }
        return new Password(password);
    }
}
