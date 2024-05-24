using Repositorio.Data;
using Repositorio.Interfaces;
using Servicio.Interfaces;
using Servicio;
using Microsoft.EntityFrameworkCore;
using Servicio.Mapeos;
using Repositorio;


var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("connectionWindows");

//Inyección de Dependencias

builder.Services.AddDbContext<DbContexto>(opt => opt.UseSqlServer(connection));
builder.Services.AddAutoMapper(typeof(AutoMaperPerfil));
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<IPrestamoService, PrestamoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
