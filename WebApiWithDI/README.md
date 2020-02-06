1.Ejecutar CreateProductionVariable.bat, así
crea la variable de entorno con ámbito de usuario.
He utilizado este código para leer la
Environment de usuario:
GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", 
EnvironmentVariableTarget.User);

2.Ejecutar el contenedor de docker de Sql Server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password"
 -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest

3.Url que se ejecuta por defecto
/api/TodoItemSqlServers



Pasos para realizar el proyecto


1.Crear fichero appsettings.Production.json
2.Modificar el startup para leer variable de entorno y cargar configuración
de producción, en el método ConfigureServices
3.Crear Clase TodoItemSqlServer con los custom attributes de sql server
4.Crear Clase SqlServerTodoContext
5.En la Clase SqlServerTodoContext sobrescribir el método OnModelCreating
6.Ejecutamos este script
Add-Migration WebApiWithDI.SqlServerTodoContext -Context 
WebApiWithDI.SqlServerTodoContext

Muy importante la defaultConnection arriba del todo del fichero de settings
"ConnectionStrings": {
    "DefaultConnection": "server=.,1434;database=TodoItem;User Id=sa;Password=yourStrong(!)Password;"
  },
7.Actualizamos la base de datos Especificando el contexto
update-database -Context WebApiWithDI.SqlServerTodoContext

8.Generamos el nuevo controlador
9.Cambiamos las variables de entorno.

https://localhost:44344/api/TodoItem
https://localhost:44344/api/TodoItemSqlServers