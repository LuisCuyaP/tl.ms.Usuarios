using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Roles;

public class Rol : Entity
{
    private Rol(
        Guid id,
        string nombreRol,
        string descripcion
        ) : base(id)
    {
        NombreRol = nombreRol;
        Descripcion = descripcion;
    }

    public string NombreRol { get; private set; }
    public string Descripcion { get; private set; }

    public static Result<Rol> Create(
        Guid id,
        string nombreRol,
        string descripcion
        )
    {
        return Result.Success(new Rol(id, nombreRol, descripcion));
    }
}