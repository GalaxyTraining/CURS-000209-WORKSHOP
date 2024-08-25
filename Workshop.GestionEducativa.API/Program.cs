using Microsoft.EntityFrameworkCore;
using Workshop.GestionEducativa.AccesoDatos.Contextos;
using Workshop.GestionEducativa.Repositorios.Implementaciones;
using Workshop.GestionEducativa.Repositorios.Interfaces;
using Workshop.GestionEducativa.Servicios.Implementaciones;
using Workshop.GestionEducativa.Servicios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion de la cadena de conexion sobre DbContext
builder.Services.AddDbContext<GestionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("BdGestionEducativaPostgreSQL"));
});

//Configuracion de inyeccion de dependecias de los repositorios
builder.Services.AddScoped<IApoderadoRepositorio, ApoderadoRepositorio>();
builder.Services.AddScoped<IAlumnoRepositorio, AlumnoRepositorio>();

//Configuracion de inyeccion de dependecias de los servicios
builder.Services.AddScoped<IApoderadoService, ApoderadoService>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
