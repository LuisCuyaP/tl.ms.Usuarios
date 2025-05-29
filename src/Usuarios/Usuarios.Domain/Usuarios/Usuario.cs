using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Shared;

namespace Usuarios.Domain.Usuarios;
public class Usuario : Entity
{
    public readonly List<DobleFactorAutenticacion> autenticacions = new();
    private Usuario(Guid id, string nombresPersona, string apellidoPaterno, string apellidoMaterno, Password password, NombreUsuario nombreUsuario, DateTime fechaNacimiento, CorreoElectronico correoElectronico, Direccion direccion, Estados estado, DateTime fechaUltimoCambio) : base(id)
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

    public static Usuario Create(Guid id, string nombresPersona, string apellidoPaterno, string apellidoMaterno, Password password, NombreUsuario nombreUsuario, DateTime fechaNacimiento, CorreoElectronico correoElectronico, Direccion? direccion, DateTime FechaUltimoCambio)
    {
        return new Usuario(id, nombresPersona, apellidoPaterno, apellidoMaterno, password, nombreUsuario, fechaNacimiento, correoElectronico, direccion, Estados.Activo, FechaUltimoCambio);
    }
}