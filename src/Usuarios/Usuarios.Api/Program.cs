using Usuarios.Infraestructure;
using Usuarios.Application;
using Usuarios.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//1. PARA LEVANTAR POR PRIMER VEZ
// 1.1 COMENTAR SEEDDATA, APPLYMIGRATIONS DEBE CREAR PRIMERO LAS TABLAS
// 1.2 DESCOMENTAR SEEDDATA Y LEVANTAR DE NUEVO, PARA LLENAR CON DATOS INICIALES
app.ApplyMigrations();
app.SeedData();

app.UseCustomExceptionHandler();

//app.UseAuthorization();
app.MapControllers();

app.Run();
