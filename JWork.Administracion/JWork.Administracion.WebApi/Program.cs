using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Business;
using JWork.Administracion.WebApi;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using static JWork.Administracion.Business.Aplicacion.Actividad.Registar;
using static JWork.Administracion.Business.Aplicacion.Area.Registrar;
using static JWork.Administracion.Business.Aplicacion.ConceptoCalificacion.Registrar;
using static JWork.Administracion.Business.Aplicacion.Habilidad.Registrar;
using static JWork.Administracion.Business.Aplicacion.TipoDocumento.Registrar;
using static JWork.Administracion.Business.Aplicacion.TipoPersona.Registrar;
using static JWork.Administracion.Business.Aplicacion.UnidadMedida.Registrar;

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
builder.Services.AddScoped<IRepositoryConceptoCalificacion, RepositoryConceptoCalificacion>();
builder.Services.AddScoped<IRepositoryOficio, RepositoryOficio>();  
builder.Services.AddScoped<IRepositoryDivipola, RepositoryDivipola>(); 
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ConceptoCalificacionRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ConceptoCalificacionUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ConceptoCalificacionEliminarCommand).Assembly);

    cfg.RegisterServicesFromAssembly(typeof(UnidadMedidaRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UnidadMedidaUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UnidadMedidaEliminarCommand).Assembly);


    cfg.RegisterServicesFromAssembly(typeof(AreaRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AreaUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AreaEliminarCommand).Assembly);


    cfg.RegisterServicesFromAssembly(typeof(HabilidadRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(HabilidadUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(HabilidadEliminarCommand).Assembly);



    cfg.RegisterServicesFromAssembly(typeof(TipoDocumentoRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(TipoDocumentoUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(TipoDocumentoEliminarCommand).Assembly);


    cfg.RegisterServicesFromAssembly(typeof(TipoPersonaRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(TipoPersonaUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(TipoPersonaEliminarCommand).Assembly);


    cfg.RegisterServicesFromAssembly(typeof(ActividadRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ActividadUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ActividadEliminarCommand).Assembly);

});

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn("UserId", System.Data.SqlDbType.VarChar),
        new SqlColumn("IpAddress", System.Data.SqlDbType.VarChar)
    }
};
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("ConexionSerilog"),
        sinkOptions: new MSSqlServerSinkOptions { TableName = "ErrorLogs", AutoCreateSqlTable = true },
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
        columnOptions: columnOptions)
    .CreateLogger();

builder.Host.UseSerilog();

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
