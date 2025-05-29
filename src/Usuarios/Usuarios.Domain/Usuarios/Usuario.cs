using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Events;
using Usuarios.Domain.Roles;
using Usuarios.Domain.Shared;

namespace Usuarios.Domain.Usuarios;
public class Usuario : Entity
{
    public readonly List<DobleFactorAutenticacion> autenticacions = new();
    private Usuario(Guid id, string nombresPersona, string apellidoPaterno, string apellidoMaterno, Password password, NombreUsuario nombreUsuario, DateTime fechaNacimiento, CorreoElectronico correoElectronico, Direccion direccion, Estados estado, DateTime fechaUltimoCambio, Guid rolId) : base(id)
    {
        NombresPersona = nombresPersona;
        ApellidoPaterno = apellidoPaterno;
        ApellidoMaterno = apellidoMaterno;
        Password = password;
        NombreUsuario = nombreUsuario;
        FechaNacimiento = fechaNacimiento;
        CorreoElectronico = correoElectronico;
        Direccion = direccion;
        Estado = estado;
        FechaUltimoCambio = fechaUltimoCambio;
        RolId = rolId;
    }

    public string NombresPersona { get; private set; }
    public string ApellidoPaterno { get; private set; }
    public string ApellidoMaterno { get; private set; }
    public Password Password { get; private set; }
    public NombreUsuario NombreUsuario { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public CorreoElectronico CorreoElectronico { get; private set; }
    public Direccion? Direccion { get; private set; }
    public Estados Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }
    public IReadOnlyList<DobleFactorAutenticacion> dobleFactorAutenticacions => autenticacions.AsReadOnly();
    public Rol? Rol { get; private set; }
    public Guid RolId { get; private set; }

    public static Result<Usuario> Create(string nombresPersona, string apellidoPaterno, string apellidoMaterno, Password password, DateTime fechaNacimiento, CorreoElectronico correoElectronico, Direccion? direccion, DateTime fechaUltimoCambio, Guid rolId, NombreUsuarioService nombreUsuarioService)
    {
        var nombreUsuario = nombreUsuarioService.GenerarNombreUsuario(nombresPersona, apellidoPaterno);
        var usuario = new Usuario(Guid.NewGuid(), nombresPersona, apellidoPaterno, apellidoMaterno, password, nombreUsuario.Value, fechaNacimiento, correoElectronico, direccion, Estados.Activo, fechaUltimoCambio, rolId);
        usuario.RaiseDomainEvent(new UserCreateDomainEvent(usuario.Id));
        return Result.Success(usuario);
    }
}