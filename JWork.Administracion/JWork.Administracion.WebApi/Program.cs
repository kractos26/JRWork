using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Business;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JrworkContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"));
});
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IRepositoryActividad,RepositoryActividad>();
builder.Services.AddScoped<IRepositoryArea,RepositoryArea>();   
builder.Services.AddScoped<IRepositoryTipoPersona,RepositoryTipoPersona>();
builder.Services.AddScoped<IRepositoryHabilidad, RepositoryHabilidad>();
builder.Services.AddScoped<IRepositoryTipoDocumento,RepositoryTipoDocumento>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
