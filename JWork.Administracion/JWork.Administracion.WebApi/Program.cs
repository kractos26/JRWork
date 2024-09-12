using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Business;
using JWork.Administracion.Business.Aplicacion.Actividad;
using JWork.Administracion.WebApi;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using static JWork.Administracion.Business.Aplicacion.Actividad.Registrar;
using static JWork.Administracion.Business.Aplicacion.Area.Buscar;
using static JWork.Administracion.Business.Aplicacion.Area.Registrar;
using static JWork.Administracion.Business.Aplicacion.ConceptoCalificacion.Buscar;
using static JWork.Administracion.Business.Aplicacion.ConceptoCalificacion.Registrar;
using static JWork.Administracion.Business.Aplicacion.Divipola.Buscar;
using static JWork.Administracion.Business.Aplicacion.Divipola.Registrar;
using static JWork.Administracion.Business.Aplicacion.Habilidad.Buscar;
using static JWork.Administracion.Business.Aplicacion.Habilidad.Registrar;
using static JWork.Administracion.Business.Aplicacion.Oficio.Buscar;
using static JWork.Administracion.Business.Aplicacion.TipoDocumento.Buscar;
using static JWork.Administracion.Business.Aplicacion.TipoDocumento.Registrar;
using static JWork.Administracion.Business.Aplicacion.TipoIdentificacion.Buscar;
using static JWork.Administracion.Business.Aplicacion.TipoIdentificacion.Registrar;
using static JWork.Administracion.Business.Aplicacion.TipoPersona.Buscar;
using static JWork.Administracion.Business.Aplicacion.TipoPersona.Registrar;
using static JWork.Administracion.Business.Aplicacion.UnidadMedida.Buscar;
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
builder.Services.AddTransient<IRepositoryTipoIdentificacion, RepositoryTipoIdentificacion>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

ConfigurarMediaTR(builder);
ConfigurarMediaTRBucar(builder);

var connectionString = builder.Configuration.GetConnectionString("ConexionSerilog");


// Configura las opciones para el sink de MSSQL Server
var sinkOptions = new MSSqlServerSinkOptions
{
    TableName = "Logs",
    AutoCreateSqlTable = true // Crea la tabla automáticamente si no existe
};

// Configuración de las columnas adicionales (opcional)
var columnOptions = new ColumnOptions();
columnOptions.Store.Remove(StandardColumn.Properties);
columnOptions.AdditionalColumns = new Collection<SqlColumn>
{
    new SqlColumn { ColumnName = "UserName", DataType = System.Data.SqlDbType.NVarChar, DataLength = 50 }
};

// Configura Serilog con la nueva interfaz MSSqlServerSinkOptions
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)  // Ajustar niveles mínimos para otros namespaces
    .Enrich.FromLogContext()
    .WriteTo.Console()  // Para mostrar en la consola
    .WriteTo.MSSqlServer(
        connectionString: connectionString,
        sinkOptions: sinkOptions,  // Usa las nuevas opciones
        restrictedToMinimumLevel: LogEventLevel.Error,  // Captura errores
        columnOptions: columnOptions  // Opciones de columnas
    )
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

static void ConfigurarMediaTR(WebApplicationBuilder builder)
{
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
}

static void ConfigurarMediaTRBucar(WebApplicationBuilder builder)
{
    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(Buscar.ActividadBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(Buscar.ActividadBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(Buscar.ActividadBuscarTodoCommand).Assembly);

        cfg.RegisterServicesFromAssembly(typeof(AreaBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(AreaBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(AreaBuscarTodoCommand).Assembly);


        cfg.RegisterServicesFromAssembly(typeof(ConceptoCalificacionBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(ConceptoCalificacionBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(ConceptoCalificacionBuscarTodoCommand).Assembly);

        cfg.RegisterServicesFromAssembly(typeof(DivipolaBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(DivipolaBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(DivipolaBuscarTodoCommand).Assembly);


        cfg.RegisterServicesFromAssembly(typeof(HabilidadBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(HabilidadBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(HabilidadBuscarTodoCommand).Assembly);

        cfg.RegisterServicesFromAssembly(typeof(OficioBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(OficioBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(OficioBuscarTodoCommand).Assembly);

        cfg.RegisterServicesFromAssembly(typeof(TipoDocumentoBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(TipoDocumentoBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(TipoDocumentoBuscarTodoCommand).Assembly);


        cfg.RegisterServicesFromAssembly(typeof(TipoIdentificacionBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(TipoIdentificacionBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(TipoIdentificacionBuscarTodoCommand).Assembly);

        cfg.RegisterServicesFromAssembly(typeof(TipoPersonaBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(TipoPersonaBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(TipoPersonaBuscarTodoCommand).Assembly);

        cfg.RegisterServicesFromAssembly(typeof(UnidadMedidaBuscarCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(UnidadMedidaBuscarIdCommand).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(UnidadMedidaBuscarTodoCommand).Assembly);
    });
}