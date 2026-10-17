# tarea/algoritmo Repositorio de Gastos

Programa de consola en C# que registra y consulta gastos en la base de datos `GastosDB`.

## Archivos principales

- Program.cs: muestra el menú, valida los datos y presenta los gastos.
- Gasto.cs: contiene la clase que representa cada gasto.
- GastoRepositorio.cs: se conecta con SQL Server para insertar y listar gastos.
- `CrearGastosDB.sql: script para crear la base de datos, la tabla y los datos iniciales.

## Cómo ejecutar

1. Abre la solución en Visual Studio.
2. Verifica que exista la base de datos GastosDB en la instancia (localdb)\GastosTarea.
3. Confirma que esté instalado el paquete NuGet Microsoft.Data.SqlClient.
4. Ejecuta el proyecto de consola con Ctrl + F5.
5. Usa el menú para registrar gastos, listarlos o salir.

## Video de explicación

En el video muestro el código y las pruebas que realicé:

[Ver video en Google Drive](https://drive.google.com/file/d/1tpB8pVnSwyybM9-Y60xwalhX9c1V2B1E/view?usp=drive_link)

