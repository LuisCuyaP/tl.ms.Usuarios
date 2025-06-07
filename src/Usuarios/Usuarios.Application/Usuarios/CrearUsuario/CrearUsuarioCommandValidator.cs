using FluentValidation;

namespace Usuarios.Application.Usuarios.CrearUsuario;

public class CrearUsuarioCommandValidator : AbstractValidator<CrearUsuarioCommand>
{
    public CrearUsuarioCommandValidator()
    {
        RuleFor(u => u.CorreoElectronico).NotEmpty()
        .WithMessage("El corrreo electronico no puede ser vacio");

        RuleFor(u => u.ApellidoPaterno).NotEmpty();

        RuleFor(u => u.NombresPersona).NotEmpty();

        RuleFor(u => u.FechaNacimiento).NotEmpty();

        RuleFor(u => u.FechaNacimiento).LessThan(DateTime.Now)
        .WithMessage("La fecha de nacimiento no es valida");
    }
}