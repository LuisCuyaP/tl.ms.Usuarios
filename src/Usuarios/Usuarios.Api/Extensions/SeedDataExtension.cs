using Bogus;
using Dapper;
using Usuarios.Application.Abstractions.Data;

namespace Usuarios.Api.Extensions;

public static class SeedDataExtension
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();

        using var connection = sqlConnectionFactory.CreateConnection();

        List<object> roles;

        const string sqlContarRoles = "SELECT COUNT(*) FROM roles";

        if (connection.ExecuteScalar<int>(sqlContarRoles) <= 0)
        {
            roles = [
                new { Id = Guid.NewGuid(), NombreRol = "Docente", Descripcion = "Usuario docente" } ,
                new { Id = Guid.NewGuid(), NombreRol = "Estudiante", Descripcion = "Usuario estudiante" } ,
            ];

            const string sqlInsertarRoles = "INSERT INTO roles (id,nombre_rol,descripcion) VALUES (@Id,@NombreRol,@Descripcion)";

            connection.Execute(sqlInsertarRoles, roles);

            List<object> usuarios = new();

            for (int i = 0; i < 100; i++)
            {
                var fake = new Faker();
                int indexRol = fake.Random.Number(0, roles.Count() - 1);
                var maximoFN = fake.Date.Past(50);

                var usuario = new
                {
                    id = Guid.NewGuid(),
                    nombres_persona = fake.Person.FirstName,
                    apellido_paterno = fake.Person.LastName,
                    apellido_materno = fake.Person.LastName,
                    password = fake.Person.UserName,
                    nombre_usuario = fake.Person.UserName,
                    //la fecha nacimiento tendra un rango en 0 a 50 años
                    fecha_nacimiento = fake.Date.Between(maximoFN, DateTime.UtcNow),
                    correo_electronico = fake.Person.Email,
                    direccion_pais = fake.Address.Country(),
                    direccion_departamento = fake.Address.City(),
                    direccion_provincia = fake.Address.State(),
                    direccion_distrito = fake.Address.StreetName(),
                    direccion_calle = fake.Address.StreetAddress(),
                    estado = fake.PickRandom("Activo", "Inactivo"),
                    fecha_ultimo_cambio = DateTime.UtcNow,
                    //lista aleatoria de la base que tenga la lista de roles
                    rol_id = (Guid)((dynamic)roles[indexRol]).Id
                };

                usuarios.Add(usuario);
            }

            const string sqlInsertarUsuarios = """
              INSERT INTO usuarios 
                (id, 
                nombres_persona, 
                apellido_paterno, 
                apellido_materno, 
                password, 
                nombre_usuario, 
                fecha_nacimiento, 
                correo_electronico, 
                direccion_pais, 
                direccion_departamento, 
                direccion_provincia, 
                direccion_distrito, 
                direccion_calle, 
                estado, 
                fecha_ultimo_cambio, 
                rol_id) 
            VALUES 
                (@id, 
                @nombres_persona, 
                @apellido_paterno, 
                @apellido_materno, 
                @password, 
                @nombre_usuario,
                @fecha_nacimiento, 
                @correo_electronico, 
                @direccion_pais, 
                @direccion_departamento, 
                @direccion_provincia, 
                @direccion_distrito, 
                @direccion_calle, 
                @estado, 
                @fecha_ultimo_cambio, 
                @rol_id);
            """;

            connection.Execute(sqlInsertarUsuarios, usuarios);

        }



    }
}