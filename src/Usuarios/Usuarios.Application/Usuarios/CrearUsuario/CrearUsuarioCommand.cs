using Usuarios.Application.Abstractions.Messaging;

namespace Usuarios.Application.Usuarios.CrearUsuario;

public sealed record CrearUsuarioCommand
(
    string NombresPersona,
    string ApellidoPaterno,
    string ApellidoMaterno,
    string Password,
    DateTime FechaNacimiento,
    string CorreoElectronico,
    string Pais,
    string Departamento,
    string Provincia,
    string Distrito,
    string Calle,
    string Rol
) : ICommand<Guid>;