using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public class NombreUsuarioService
{
    public Result<NombreUsuario> GenerarNombreUsuario(string nombre, string apellido)
    {
       var nombreUsuario = $"{nombre.Substring(0,1)}.{apellido.Trim()}".ToUpper();
        return NombreUsuario.Create(nombreUsuario);
    }
}
