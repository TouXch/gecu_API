using gecu_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TRAYENDO LA CADENA DE CONEXION DESDE APPSETTINGS.JSON
var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.10.2-mariadb");
builder.Services.AddEntityFrameworkMySql().AddDbContext<GecubdContext>(options
    => options.UseMySql(builder.Configuration.GetConnectionString("cadenaSQL"), serverVersion));

//AGREGANDO LOS CORS PARA PERMITIR EL ACCESO DESDE TODOS LOS ORIGENES
var misReglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: misReglasCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
