1. dotnet new globaljson --sdk-version 9.0.203 --force
2. dotnet new classlib -o src/Usuarios/Usuarios.Domain
3. dotnet new sln -n Usuarios
4. dotnet sln add .\src\Usuarios\Usuarios.Domain\Usuarios.Domain.csproj
