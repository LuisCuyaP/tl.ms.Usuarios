namespace Usuarios.Domain.Abstractions;

public record Error(string Code, string Message)
{
    public static Error None => new(string.Empty, string.Empty);
    public static Error NullValue => new("NullValue", "The value cannot be null.");
}
