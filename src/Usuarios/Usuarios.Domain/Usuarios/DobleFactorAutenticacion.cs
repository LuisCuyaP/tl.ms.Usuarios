using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Shared;

namespace Usuarios.Domain.Usuarios;

public class DobleFactorAutenticacion : Entity
{
    private DobleFactorAutenticacion(Guid id, Guid usuarioId, TipoDobleFactor tipo, string codigo, Estados estado, DateTime fechaCreacion) : base(id)
    {
        UsuarioId = usuarioId;
        Tipo = tipo;
        Codigo = codigo;
        Estado = estado;
        FechaCreacion = fechaCreacion;
    }

    public Guid UsuarioId { get; private set; }
    public TipoDobleFactor Tipo { get; private set; }
    public string Codigo { get; private set; }
    public Estados Estado { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public static DobleFactorAutenticacion Create(Guid usuarioId, TipoDobleFactor tipo, string codigo, Estados estado, DateTime fechaCreacion)
    {
        return new DobleFactorAutenticacion(new Guid(), usuarioId, tipo, codigo, estado, fechaCreacion);
    }
}
