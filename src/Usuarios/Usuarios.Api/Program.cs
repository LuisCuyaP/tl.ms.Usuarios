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

app.ApplyMigrations();

//app.UseAuthorization();
app.MapControllers();

app.Run();
