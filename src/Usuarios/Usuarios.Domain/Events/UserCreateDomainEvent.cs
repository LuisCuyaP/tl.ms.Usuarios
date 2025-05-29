using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Events;

//sealed -> no podra ser heredada por otra clase
public sealed record UserCreateDomainEvent(Guid IdUsuario) : IDomainEvent;