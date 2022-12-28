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
});

app.MapGet("/api/productos", async ([FromServices] ProductoContext DbContext) =>
{
    return Results.Ok(DbContext.Productos);
});


app.MapGet("/api/productos/{id}", async ([FromServices] ProductoContext DbContext, [FromRoute] int id) =>
{



    return Results.Ok(DbContext.Productos.Find(id));


});

app.MapPost("/api/productos", async ([FromServices] ProductoContext DbContext, [FromBody] Producto producto) =>
{

    await DbContext.AddAsync(producto);

    await DbContext.SaveChangesAsync();

    return Results.Ok();
});


app.Run();
