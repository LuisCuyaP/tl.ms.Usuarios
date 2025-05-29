using System.Text.RegularExpressions;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public record CorreoElectronico
{
    //init = una vez el valor se setea no se puede modificar
    public string Value { get; init; }
    private CorreoElectronico(string value)
    {
        Value = value;
    }
    public static Result<CorreoElectronico> Create(string correo)
    {
        if (!EsCorreoValido(correo))
        {
            return Result.Failure<CorreoElectronico>(UsuarioErrores.CorreoElectronicoInvalido);
        }
        return new CorreoElectronico(correo);
    }
    public static bool EsCorreoValido(string correo)
    {
        if (string.IsNullOrWhiteSpace(correo))
        {
            return false;
        }
        const string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.Match(correo, emailPattern).Success;
    }
}
