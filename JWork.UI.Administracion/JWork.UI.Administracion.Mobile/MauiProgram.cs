using CommunityToolkit.Maui;
using JWork.UI.Administracion.Mobile.ViewModels;
using JWork.UI.Administracion.Mobile.ViewModels.Buscar;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Mobile.Views.Buscar;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Servicios;
using Plugin.LocalNotification;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.DataBase.Repositories;
using Microsoft.EntityFrameworkCore;
using UXDivers.Grial;
using Microsoft.Extensions.Logging;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.Mobile.Platforms.Android;


namespace JWork.UI.Administracion.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
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
                    handlers.AddHandler<NavigationPage, UXDivers.Grial.GrialNavigationPageHandler>();
                    handlers.AddHandler<Label, JWork.UI.Administracion.Mobile.LabelHandler>();
                });





            string dbPath = new DatabaseRutaService().GetRuta("jwork.db");
            builder.Services.AddDbContext<JWorkContext>(options =>
            options.UseSqlite($"Data Source={dbPath}").EnableSensitiveDataLogging()
                   .LogTo(Console.WriteLine, LogLevel.Information)
            
            );


            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Registro de servicios de navegación y páginas
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Registro de páginas
            builder.Services.AddSingleton<PopupService>();
            builder.Services.AddTransient<ActividadPage>();
            builder.Services.AddTransient<AreaPopup>();
            builder.Services.AddTransient<OficioPage>();
            builder.Services.AddTransient<TipoDocumentoPage>();
            builder.Services.AddTransient<TipoIdentificacionPage>();
            builder.Services.AddTransient<HabilidadPage>();
            builder.Services.AddTransient<UnidadMedidaPage>();
            builder.Services.AddTransient<DivipolaPage>();
            builder.Services.AddTransient<ConceptoCalificacionPage>();

            // Registro de páginas adicionales con plural (listas)
            builder.Services.AddTransient<ActividadesPage>();
            builder.Services.AddTransient<AreasPage>();
            builder.Services.AddTransient<OficiosPage>();
            builder.Services.AddTransient<TiposDocumentosPage>();
            builder.Services.AddTransient<TiposIdentificacionesPage>();
            builder.Services.AddTransient<HabilidadesPage>();
            builder.Services.AddTransient<UnidadesMedidasPage>();
            builder.Services.AddTransient<DivipolasPage>();
            builder.Services.AddTransient<ConceptoCalificacionesPage>();

            // Registro de ViewModels
            builder.Services.AddTransient<ActividadViewModel>();
            builder.Services.AddTransient<AreaViewModel>();
            builder.Services.AddTransient<OficioViewModel>();
            builder.Services.AddTransient<TipoDocumentoViewModel>();
            builder.Services.AddTransient<TipoIdentificacionViewModel>();
            builder.Services.AddTransient<HabilidadViewModel>();
            builder.Services.AddTransient<UnidadMedidaViewModel>();
            builder.Services.AddTransient<DivipolaViewModel>();
            builder.Services.AddTransient<ConceptoCalificacionViewModel>();

            // Registro de GridViewModels (para listas y grids)
            builder.Services.AddTransient<ActividadGridViewModel>();
            builder.Services.AddTransient<AreaGridViewModel>();
            builder.Services.AddTransient<OficioGridViewModel>();
            builder.Services.AddTransient<TipoDocumentoGridViewModel>();
            builder.Services.AddTransient<TipoIdentificacionGridViewModel>();
            builder.Services.AddTransient<HabilidadGridViewModel>();
            builder.Services.AddTransient<UnidadMedidaGridViewModel>();
            builder.Services.AddTransient<DivipolaGridViewModel>();
            builder.Services.AddTransient<ConceptoCalificacionGridViewModel>();

            // Registro de servicios
            builder.Services.AddSingleton<ActividadService>();
            builder.Services.AddSingleton<AreaService>();
            builder.Services.AddSingleton<ConceptoCalificacionService>();
            builder.Services.AddSingleton<HabilidadService>();
            builder.Services.AddSingleton<OficioService>();
            builder.Services.AddSingleton<DivipolaService>();
            builder.Services.AddSingleton<TipoDocumentoService>();
            builder.Services.AddSingleton<TipoIdentificacionService>();
            builder.Services.AddSingleton<UnidadMedidaService>();
            builder.Services.AddSingleton<TipoPersonaService>();

            // Registro de capas de lógica de negocio (Business Layer)
            builder.Services.AddSingleton<ActividadBL>();
            builder.Services.AddSingleton<AreaBL>();
            builder.Services.AddSingleton<ConceptoCalificacionBL>();
            builder.Services.AddSingleton<HabilidadBL>();
            builder.Services.AddSingleton<OficioBL>();
            builder.Services.AddSingleton<DivipolaBL>();
            builder.Services.AddSingleton<TipoDocumentoBL>();
            builder.Services.AddSingleton<TipoIdentificacionBL>();
            builder.Services.AddSingleton<UnidadMedidaBL>();

            builder.Services.AddTransient(typeof(IRepositorio<>), typeof(Repositorio<>));
            builder.Services.AddTransient<IRepositoryActividad, RepositoryActividad>();
            builder.Services.AddTransient<IRepositoryArea, RepositoryArea>();
            builder.Services.AddTransient<IRepositoryConceptoCalificacion, RepositoryConceptoCalificacion>();
            builder.Services.AddTransient<IRepositoryDivipola, RepositoryDivipola>();
            builder.Services.AddTransient<IRepositoryHabilidad, RepositoryHabilidad>();
            builder.Services.AddTransient<IRepositoryOficio, RepositoryOficio>();
            builder.Services.AddTransient<IRepositoryUnidadMedida, RepositoryUnidadMedida>();
            builder.Services.AddTransient<IRepositoryTipoPersona, RepositoryTipoPersona>();
            builder.Services.AddSingleton<IDatabaseRutaService, DatabaseRutaService>();
       
            return builder.Build();
        }
    }
}
