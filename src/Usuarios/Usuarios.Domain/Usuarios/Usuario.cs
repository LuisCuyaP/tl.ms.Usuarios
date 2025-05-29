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
        string continente,
        string pais, 
        string departamento, 
        string provincia, 
        string distrito, 
        string calle, 
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
        Continente = continente;
        Pais = pais;
        Departamento = departamento;
        Provincia = provincia;
        Distrito = distrito;
        Calle = calle;
        Estado = estado;
        FechaUltimoCambio = fechaUltimoCambio;
    }
    //el id lo hereda de entity asi como los demas metodos
    public string NombresPersona { get; private set; }
    public string ApellidoPaterno { get; private set; }
    public string ApellidoMaterno { get; private set; }
    public string Password { get; private set; }
    public string NombreUsuario { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public string CorreoElectronico { get; private set; }
    public string Continente { get; private set; }
    public string Pais { get; private set; }
    public string Departamento { get; private set; }
    public string Provincia { get; private set; }
    public string Distrito { get; private set; }
    public string Calle { get; private set; }
    public int Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }
    
}
