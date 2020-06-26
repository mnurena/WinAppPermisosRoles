# WinAppPermisosRoles
Aplicación desarrollada para la administración de Roles y permisos de usuarios para el acceso a determinadas funciones o acciones en un sistema, Estos permisos se guardan en una cadena de texto en formato JSON.

## Requerimientos
 - .Net Framework 4.7.2
 - SQL Server 2016 o Superior

## Como Usarlo?
 - Descarga o clona el repositorio y abrirlo con Visual Studio
 - Ejecutar Script SQL ubicado en la carpeta `script`.
 - Generar la cadena de conexión a la BD y luego encriptar con el formulario `genCadena.vb` y guardarla en el archivo `app.config` en:
 `
      <connectionStrings>
      <add name="Connection" connectionString="YOUR STRING CONNECTION ENCRYP"/>
      </connectionStrings>
 `
 - Probar iniciar Sesion con el login, con los siguientes datos.
    - Usuario: usuario2
    - Contraseña: 123456
   
 ## Mas información:
 Para mas información sobre el uso e implementación del sistema en otros sistemas en [ProgramacionX.Net](https://programacionx.net/programacion/sistema-de-permisos-y-roles-de-usuarios-en-visual-net/)
 
