using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Domain.Shared;
using Usuarios.Domain.Usuarios;

namespace Usuarios.Infraestructure.Configurations;

public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");

        builder.HasKey(usuario => usuario.Id);

        builder.Property(usuario => usuario.NombresPersona)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(usuario => usuario.ApellidoPaterno)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(usuario => usuario.ApellidoMaterno)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(usuario => usuario.Password)
            .HasMaxLength(200)
            .HasConversion(password =>
             password.Value, value => Password.Create(value).Value);


        builder.Property(usuario => usuario.NombreUsuario)
            .HasMaxLength(200)
            .HasConversion(nombre =>
             nombre.Value, value => NombreUsuario.Create(value).Value);

        builder.Property(nacimiento => nacimiento.FechaNacimiento).IsRequired();

        builder.Property(correo => correo.CorreoElectronico)
            .HasMaxLength(200)
            .HasConversion(correo =>
             correo.Value, value => CorreoElectronico.Create(value).Value);

        //cuando se cree la tabla usuario, dentro de la tabla usuario se creara todas las columnas de la clase Direccion
        builder.OwnsOne(usuario => usuario.Direccion);

        builder.Property(usuario => usuario.Estado)
            .HasConversion(
                estado => estado.ToString(),
                estado => (Estados)Enum.Parse(typeof(Estados), estado))
            .IsRequired();

        builder.Property(cambio => cambio.FechaUltimoCambio).IsRequired();

        builder.HasOne(usuario => usuario.Rol)
        .WithMany()
        .HasForeignKey(usuario => usuario.RolId)
        .IsRequired();

        builder.Property<uint>("Version")
            .IsRowVersion()
            .IsConcurrencyToken();
    }
}