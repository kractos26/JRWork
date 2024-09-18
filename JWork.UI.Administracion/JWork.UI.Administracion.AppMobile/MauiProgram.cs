using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.ViewModels;
using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.AppMobile.Views.Buscar;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JWork.UI.Administracion.AppMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                });

         


#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Registro de servicios de navegación y páginas
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Registro de páginas
            builder.Services.AddTransient<ActividadPage>();
            builder.Services.AddTransient<AreaPage>();
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
            builder.Services.AddTransient<TipoDocumentosPage>();
            builder.Services.AddTransient<TipoIdentificacionesPage>();
            builder.Services.AddTransient<HabilidadesPage>();
            builder.Services.AddTransient<UnidadMedidasPage>();
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

            return builder.Build();
        }
    }
}
