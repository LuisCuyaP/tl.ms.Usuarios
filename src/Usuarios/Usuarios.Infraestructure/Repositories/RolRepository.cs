using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Roles;

namespace Usuarios.Infraestructure.Repositories;

internal sealed class RolRepository : Repository<Rol>, IRolRepository
{
    public RolRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Rol?> GetByNameAsync(string nombreRol, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Rol>()
            .FirstOrDefaultAsync(rol => rol.NombreRol == nombreRol, cancellationToken);
    }
}