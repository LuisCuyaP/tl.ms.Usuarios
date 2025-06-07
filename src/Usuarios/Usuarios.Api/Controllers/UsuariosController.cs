using MediatR;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Application.Usuarios.CrearUsuario;
using Usuarios.Application.Usuarios.GetUsuario;

namespace Usuarios.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly ISender _sender;

    public UsuariosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        CrearUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CrearUsuarioCommand(
            request.NombrePersona,
            request.ApellidoPaterno,
            request.ApellidoMaterno,
            request.Password,
            request.FechaNacimiento,
            request.CorreoElectronico,
            request.Pais,
            request.Departamento,
            request.Provincia,
            request.Distrito,
            request.Calle,
            request.Rol);

        //el obj command es publico, pero el que ejecuta es el handler
        //COMMAND: PARA POST,PUT, DELETE
        //sender lo que hace es llamar al command(CrearUsuarioCommand), pero CrearUsuarioCommand siempre tendra asociado a CrearUsuarioCommandHandler
        //al final sender ejecuta la funcion asociada llamada CrearUsuarioCommandHandler
        var result = await _sender.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetUser), new { id = result.Value }, result.Value);
        }

        return BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetUsuarioQuery(id);
        //QUERY: PARA GET
        //sender lo que hace es llamar al query(GetUsuarioQuery), pero GetUsuarioQuery siempre tendra asociado a GetUsuarioQueryHandler
        //al final sender ejecuta la funcion asociada llamada GetUsuarioQueryHandler
        var result = await _sender.Send(query, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

}