using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Domain.Roles;

namespace Usuarios.Infraestructure.Configurations;

public class RolConfigurations : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(rol => rol.Id);

        builder.Property(rol => rol.NombreRol)
            .HasMaxLength(50);

        builder.Property(rol => rol.Descripcion)
            .HasMaxLength(200);

        builder.HasIndex(rol => rol.NombreRol)
            .IsUnique();

        builder.Property<uint>("Version")
            .IsRowVersion()
            .IsConcurrencyToken();

    }
}