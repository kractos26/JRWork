using CommunityToolkit.Maui;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Mobile.Platforms.Android;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.ViewModels;
using JWork.UI.Administracion.Mobile.ViewModels.Buscar;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Mobile.Views.Buscar;
using JWork.UI.Administracion.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using UXDivers.Grial;


namespace JWork.UI.Administracion.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            _ = builder
                .UseMauiApp<App>().UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                    fonts.AddFont("materialdesignicons-webfont.ttf", "Material Design Icons");
                    fonts.AddFont("Roboto-Regular.ttf", "Sans");
                })
.UseMauiCommunityToolkit()
                .UseGrial()
                .ConfigureMauiHandlers(handlers =>
                {
                    _ = handlers.AddHandler<NavigationPage, GrialNavigationPageHandler>();
                 
                });





            string dbPath = new DatabaseRutaService().GetRuta("jwork.db");
            _ = builder.Services.AddDbContext<JWorkContext>(options =>
            options.UseSqlite($"Data Source={dbPath}").EnableSensitiveDataLogging()
                   .LogTo(Console.WriteLine, LogLevel.Information)

            );


            _ = builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Registro de servicios de navegación y páginas
            _ = builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Registro de páginas
            _ = builder.Services.AddSingleton<PopupService>();
            _ = builder.Services.AddTransient<ActividadPage>();
            _ = builder.Services.AddTransient<AreaPopup>();
            _ = builder.Services.AddTransient<OficioPopup>();
            _ = builder.Services.AddTransient<TipoDocumentoPage>();
            _ = builder.Services.AddTransient<TipoIdentificacionPage>();
            _ = builder.Services.AddTransient<HabilidadPage>();
            _ = builder.Services.AddTransient<UnidadMedidaPage>();
            _ = builder.Services.AddTransient<DivipolaPage>();
            _ = builder.Services.AddTransient<ConceptoCalificacionPage>();

            // Registro de páginas adicionales con plural (listas)
            _ = builder.Services.AddTransient<ActividadesPage>();
            _ = builder.Services.AddTransient<AreasPage>();
            _ = builder.Services.AddTransient<OficiosPage>();
            _ = builder.Services.AddTransient<TiposDocumentosPage>();
            _ = builder.Services.AddTransient<TiposIdentificacionesPage>();
            _ = builder.Services.AddTransient<HabilidadesPage>();
            _ = builder.Services.AddTransient<UnidadesMedidasPage>();
            _ = builder.Services.AddTransient<DivipolasPage>();
            _ = builder.Services.AddTransient<ConceptoCalificacionesPage>();

            // Registro de ViewModels
            _ = builder.Services.AddTransient<ActividadViewModel>();
            _ = builder.Services.AddTransient<AreaViewModel>();
            _ = builder.Services.AddTransient<OficioViewModel>();
            _ = builder.Services.AddTransient<TipoDocumentoViewModel>();
            _ = builder.Services.AddTransient<TipoIdentificacionViewModel>();
            _ = builder.Services.AddTransient<HabilidadViewModel>();
            _ = builder.Services.AddTransient<UnidadMedidaViewModel>();
            _ = builder.Services.AddTransient<DivipolaViewModel>();
            _ = builder.Services.AddTransient<ConceptoCalificacionViewModel>();

            // Registro de GridViewModels (para listas y grids)
            _ = builder.Services.AddTransient<ActividadGridViewModel>();
            _ = builder.Services.AddTransient<AreaGridViewModel>();
            _ = builder.Services.AddTransient<OficioGridViewModel>();
            _ = builder.Services.AddTransient<TipoDocumentoGridViewModel>();
            _ = builder.Services.AddTransient<TipoIdentificacionGridViewModel>();
            _ = builder.Services.AddTransient<HabilidadGridViewModel>();
            _ = builder.Services.AddTransient<UnidadMedidaGridViewModel>();
            _ = builder.Services.AddTransient<DivipolaGridViewModel>();
            _ = builder.Services.AddTransient<ConceptoCalificacionGridViewModel>();

            // Registro de servicios
            _ = builder.Services.AddSingleton<ActividadService>();
            _ = builder.Services.AddSingleton<AreaService>();
            _ = builder.Services.AddSingleton<ConceptoCalificacionService>();
            _ = builder.Services.AddSingleton<HabilidadService>();
            _ = builder.Services.AddSingleton<OficioService>();
            _ = builder.Services.AddSingleton<DivipolaService>();
            _ = builder.Services.AddSingleton<TipoDocumentoService>();
            _ = builder.Services.AddSingleton<TipoIdentificacionService>();
            _ = builder.Services.AddSingleton<UnidadMedidaService>();
            _ = builder.Services.AddSingleton<TipoPersonaService>();

            // Registro de capas de lógica de negocio (Business Layer)
            _ = builder.Services.AddSingleton<ActividadBL>();
            _ = builder.Services.AddSingleton<AreaBL>();
            _ = builder.Services.AddSingleton<ConceptoCalificacionBL>();
            _ = builder.Services.AddSingleton<HabilidadBL>();
            _ = builder.Services.AddSingleton<OficioBL>();
            _ = builder.Services.AddSingleton<DivipolaBL>();
            _ = builder.Services.AddSingleton<TipoDocumentoBL>();
            _ = builder.Services.AddSingleton<TipoIdentificacionBL>();
            _ = builder.Services.AddSingleton<UnidadMedidaBL>();

            _ = builder.Services.AddTransient(typeof(IRepositorio<>), typeof(Repositorio<>));
            _ = builder.Services.AddTransient<IRepositoryActividad, RepositoryActividad>();
            _ = builder.Services.AddTransient<IRepositoryArea, RepositoryArea>();
            _ = builder.Services.AddTransient<IRepositoryConceptoCalificacion, RepositoryConceptoCalificacion>();
            _ = builder.Services.AddTransient<IRepositoryDivipola, RepositoryDivipola>();
            _ = builder.Services.AddTransient<IRepositoryHabilidad, RepositoryHabilidad>();
            _ = builder.Services.AddTransient<IRepositoryOficio, RepositoryOficio>();
            _ = builder.Services.AddTransient<IRepositoryUnidadMedida, RepositoryUnidadMedida>();
            _ = builder.Services.AddTransient<IRepositoryTipoPersona, RepositoryTipoPersona>();
            _ = builder.Services.AddSingleton<IDatabaseRutaService, DatabaseRutaService>();
            builder.Services.AddTransient<DatabaseInicializar>();
            return builder.Build();
        }
    }
}
