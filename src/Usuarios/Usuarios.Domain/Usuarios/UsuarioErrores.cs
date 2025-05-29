using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public class UsuarioErrores
{
    public static Error CorreoElectronicoInvalido =>
        new("Usuario.CorreloElectronicoInvalido", "El correo electronico proporcionado es invalido");
    public static Error PasswordInvalido =>
        new("Usuario.PasswordInvalido", "El password proporcionado es invalido, debe tener al menos 8 caracteres");
    public static Error NombreUsuarioInvalido =>
        new("Usuario.NombreUsuarioInvalido", "El nombre de usuario no puede estar vacio o ser nulo");
}
