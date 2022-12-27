using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_kame;
using prueba_kame.Models;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSqlServer<ProductoContext>(builder.Configuration.GetConnectionString("cnProducto"));

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] ProductoContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/productos", async ([FromServices] ProductoContext DbContext) =>
{
    return Results.Ok(DbContext.Productos);
});

app.MapPost("/api/productos", async ([FromServices] ProductoContext DbContext, [FromBody] Producto producto) =>
{

    await DbContext.AddAsync(producto);

    await DbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/productos/{id}", async ([FromServices] ProductoContext DbContext, [FromBody] Producto producto, [FromRoute] int id) =>
{

    var productoActual = DbContext.Productos.Find(id);

    if (productoActual != null)
    {
        productoActual.Nombre = producto.Nombre;
        productoActual.Detalle = producto.Detalle;
        productoActual.Precio = producto.Precio;

        await DbContext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound();

});

app.MapDelete("/api/productos/{id}", async ([FromServices] ProductoContext dbContext, [FromRoute] int id) =>
{
    var productoActual = dbContext.Productos.Find(id);

    if (productoActual != null)
    {
        dbContext.Remove(productoActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound("Producto no encontrada");

});

app.Run();
