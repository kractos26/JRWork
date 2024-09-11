using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Business;
using JWork.Administracion.WebApi;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using static JWork.Administracion.Business.Aplicacion.Actividad.Registrar;
using static JWork.Administracion.Business.Aplicacion.Area.Registrar;
using static JWork.Administracion.Business.Aplicacion.ConceptoCalificacion.Registrar;
using static JWork.Administracion.Business.Aplicacion.Divipola.Registrar;
using static JWork.Administracion.Business.Aplicacion.Habilidad.Registrar;
using static JWork.Administracion.Business.Aplicacion.TipoDocumento.Registrar;
using static JWork.Administracion.Business.Aplicacion.TipoIdentificacion.Registrar;
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
builder.Services.AddTransient(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddTransient<IRepositoryActividad,RepositoryActividad>();
builder.Services.AddTransient<IRepositoryArea,RepositoryArea>();   
builder.Services.AddTransient<IRepositoryTipoPersona,RepositoryTipoPersona>();
builder.Services.AddTransient<IRepositoryHabilidad, RepositoryHabilidad>();
builder.Services.AddTransient<IRepositoryTipoDocumento,RepositoryTipoDocumento>();
builder.Services.AddTransient<IRepositoryConceptoCalificacion, RepositoryConceptoCalificacion>();
builder.Services.AddTransient<IRepositoryOficio, RepositoryOficio>();  
builder.Services.AddTransient<IRepositoryDivipola, RepositoryDivipola>();
builder.Services.AddTransient<IRepositoryUnidadMedida, RepositoryUnidadMedida>();

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

    cfg.RegisterServicesFromAssembly(typeof(DivipolaRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DivipolaUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DivipolaEliminarCommand).Assembly);

    cfg.RegisterServicesFromAssembly(typeof(TipoIdentificacionRegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(TipoIdentificacionUpdateCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(TipoIdentificacionEliminarCommand).Assembly);
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
