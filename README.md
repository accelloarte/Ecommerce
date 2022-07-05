# ECommerce API
Este proyecto forma parte del curso de C# 10 y .NET 6 .

## Referencias de comandos utiles para programar con .NET CLI (Command Line Interface) #


## Crear un proyecto de libreria de clases 
`dotnet new classlib -o ECommerce.Entities`

_La plantilla "Biblioteca de clases" se creo correctamente._

## Crear un proyecto de pruebas unitarias con xUnit
`dotnet new xunit -o ECommerce.UnitTest`

_La plantilla "xUnit Test Project" se creo correctamente._

## Listar los archivos de una carpeta

`ls`

## Agregar un proyecto a una solucion existente

`dotnet sln add .\ECommerce.Entities\`

_Se ha agregado el proyecto "ECommerce.Entities\ECommerce.Entities.csproj" a la soluci�n._

`dotnet sln add .\ECommerce.DataAccess\`

_Se ha agregado el proyecto "ECommerce.DtaAccess\ECommerce.DataAccess.csproj" a la soluci�n._

`dotnet sln add .\ECommerce.Dto\`

_Se ha agregado el proyecto "ECommerce.Dto\ECommerce.Dto.csproj" a la soluci�n._

## Consultar que proyectos estan dentro de la solucion

`dotnet sln .\ECommerce.sln list`

## Agregar un paquete nuget a un proyecto existente

`dotnet add package Microsoft.EntityFrameworkCore --version 6.0.4`

_Tener en cuenta que de no saber el nombre del paquete y la version a instalar se puede consultar en nuget.org_

## Agregar una referencia de proyecto 
`dotnet add reference ..\ECommerce.Entities\`

_Se ha agregado la referencia "..\ECommerce.Entities\ECommerce.Entities.csproj" al proyecto._

## Comprobar si se tiene instalado Entity Framework Core Tools

`dotnet ef`

_Deberia mostrarse el resultado siguiente:_

                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 6.0.4

## Instalar EF Core Tools de manera global en el equipo

`dotnet tool install dotnet-ef --global`

_La herramienta "dotnet-ef" ya est� instalada._

## Actualizar EF Core Tools

`dotnet tool update dotnet-ef --global`

_La herramienta "dotnet-ef" se reinstal� con la versi�n estable m�s reciente (versi�n "6.0.4")._

## Crear una migracion con EF

`dotnet ef migrations add InitialMigration --startup-project .\ECommerce.API\ --project .\ECommerce.DataAccess\`

_Donde el parametro **--startup-project** es el proyecto que contiene la cadena de conexion y el parametro **--project** es el que contiene la clase con el DbContext._

## Aplicar una migracion
`dotnet ef database update --startup-project .\ECommerce.API\ --project .\ECommerce.DataAccess\`

_Esto har� que se cree la base de datos en la cadena de conexi�n de no existir._

## Crear un archivo gitignore para la solucion

`dotnet new gitignore`

_La plantilla "archivo gitignore de dotnet" se cre� correctamente._

## Iniciar el repositorio de Git

`git init`

## Agregar todos los archivos del proyecto al repositorio
`git add --all`


## Crear el primer commit
`git commit -m "Primera Clase de NET 6 Ecuador"`

## Agregar el repositorio remoto al Git
`git remote add origin https://github.com/erickorlando/ECommerce.git`

## Subir las fuentes al repositorio remoto usando la rama principal master

`git push origin master`

#CLASE 04

## Inicializar un proyecto con User-Secrets
`dotnet user-secrets init`

## Establecer/modificar un valor para User-Secrets
`dotnet user-secrets set "seccion:clave" "valor"`

## Quitar un valor para User-Secrets
`dotnet user-secrets remove "seccion:clave"`

## Listar los valores establecidos en User-Secrets
`dotnet user-secrets list`