using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;
public class Usuario : Entity
{
    private Usuario(
        Guid id,
        string nombresPersona,
        string apellidoPaterno,
        string apellidoMaterno,
        string password,
        string nombreUsuario,
        DateTime fechaNacimiento,
        string correoElectronico,
        Direccion direccion,
        int estado,
        DateTime fechaUltimoCambio
        ) : base(id)
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
    public string Password { get; private set; }
    public string NombreUsuario { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public string CorreoElectronico { get; private set; }
    public Direccion? Direccion { get; private set; }
    public int Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }

    public static Usuario Create(
        Guid id,
        string nombresPersona,
        string apellidoPaterno,
        string apellidoMaterno,
        string password,
        string nombreUsuario,
        DateTime fechaNacimiento,
        string correoElectronico,
        Direccion? direccion,
        int estado,
        DateTime FechaUltimoCambio
        )
    {
        return new Usuario(
            id,
            nombresPersona,
            apellidoPaterno,
            apellidoMaterno,
            password,
            nombreUsuario,
            fechaNacimiento,
            correoElectronico,
            direccion,
            estado,
            FechaUltimoCambio
        );

    }
}