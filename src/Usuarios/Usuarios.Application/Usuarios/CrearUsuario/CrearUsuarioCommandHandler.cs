using Usuarios.Application.Abstractions.Messaging;
using Usuarios.Application.Abstractions.Time;
using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Roles;
using Usuarios.Domain.Usuarios;

namespace Usuarios.Application.Usuarios.CrearUsuario;

internal sealed class CrearUsuarioCommandHandler : ICommandHandler<CrearUsuarioCommand, Guid>
{
    private readonly IRolRepository _rolRepository;
    private readonly IDateTimeProvider _timeProvider;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly NombreUsuarioService _serviceDomain;

    public CrearUsuarioCommandHandler(
        IRolRepository rolRepository,
        IDateTimeProvider timeProvider,
        NombreUsuarioService serviceDomain,
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork)
    {
        _rolRepository = rolRepository;
        _timeProvider = timeProvider;
        _serviceDomain = serviceDomain;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {
        var rol = await _rolRepository.GetByNameAsync(request.Rol, cancellationToken);

        if (rol is null)
        {
            return Result.Failure<Guid>(RolErrores.NoEncontrado);
        }

        //aqui en Create dentro de Usuario.Domain se 1. registra el evento de dominio
        var usuario = Usuario.Create(
            request.NombresPersona,
            request.ApellidoPaterno,
            request.ApellidoMaterno,
            Password.Create(request.Password).Value,
            request.FechaNacimiento.ToUniversalTime(),
            CorreoElectronico.Create(request.CorreoElectronico).Value,
            new Direccion(
                request.Pais,
                request.Departamento,
                request.Provincia,
                request.Distrito,
                request.Calle
            ),
            _timeProvider.CurrentTime,
            rol.Id,
            _serviceDomain
        );

        _usuarioRepository.Add(usuario.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken); //aqui se 2. publica el evento de dominio si el register es exitoso en ApplicationDbContext

        return Result.Success(usuario.Value.Id);

    }
}