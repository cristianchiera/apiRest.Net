using ApiRestEjemplo.Data;
using ApiRestEjemplo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registra controladores y servicios personalizados
builder.Services.AddControllers();
builder.Services.AddSingleton<ProductoService>();

// Configura el contexto de la base de datos con Npgsql
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger (Documentación interactiva de la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Productos",
        Version = "v1"
    });
});

var app = builder.Build();

// Swagger siempre disponible
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Productos V1");
    c.RoutePrefix = "swagger";
});

// Autorización (si agregás autenticación en el futuro)
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

// Ejecuta la aplicación
app.Run();

