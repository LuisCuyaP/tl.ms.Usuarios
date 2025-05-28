dotnet new globaljson --sdk-version 9.0.203 --force
dotnet new classlib -o src/Usuarios/Usuarios.Domain
dotnet new sln -n Usuarios
dotnet sln add .\src\Usuarios\Usuarios.Domain\Usuarios.Domain.csproj
