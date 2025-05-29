using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public class UsuarioErrores
{
    public static Error CorreoElectronicoInvalido =>
        new("Usuario.CorreloElectronicoInvalido", "El correo electronico proporcionado es invalido");
}
