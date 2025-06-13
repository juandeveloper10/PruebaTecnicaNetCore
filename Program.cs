using EscuelaMusica.Interfaces;
using EscuelaMusica.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEscuela, EscuelaRepository>();
builder.Services.AddScoped<IProfesor, ProfesorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
