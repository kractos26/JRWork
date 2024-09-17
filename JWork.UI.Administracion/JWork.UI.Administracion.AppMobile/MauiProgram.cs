using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.ViewModels;
using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Servicios;
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddTransient<ActividadPage>();
            builder.Services.AddTransient<AreaPage>();
            builder.Services.AddTransient<OficioPage>();
            builder.Services.AddTransient<TipoDocumentoPage>();
            builder.Services.AddTransient<TipoIdentificacionPage>();
            builder.Services.AddTransient<HabilidadPage>();
            builder.Services.AddTransient<UnidadMedidaPage>();
            builder.Services.AddTransient<HabilidadPage>();
            builder.Services.AddTransient<DivipolaPage>();
            builder.Services.AddTransient<ConceptoCalificacionPage>();

            builder.Services.AddTransient<ActividadVIewModels>();
            builder.Services.AddTransient<AreaViewModel>();
            builder.Services.AddTransient<OficioViewModel>();
            builder.Services.AddTransient<TipoDocumentoViewModel>();
            builder.Services.AddTransient<TipoIdentificacionViewModel>();
            builder.Services.AddTransient<HabilidadViewModel> ();
            builder.Services.AddTransient<UnidadMedidaViewModel>();
            builder.Services.AddTransient<HabilidadViewModel>();
            builder.Services.AddTransient<DivipolaViewModel>();
            builder.Services.AddTransient<ConceptoCalificacionViewModel>();

            builder.Services.AddTransient<ActividadGridViewModel>();
            builder.Services.AddTransient<AreaGridViewModel>();
            builder.Services.AddTransient<OficioGridViewModel>();
            builder.Services.AddTransient<TipoDocumentoGridViewModel>();
            builder.Services.AddTransient<TipoIdentificacionGridViewModel>();
            builder.Services.AddTransient<HabilidadGridViewModel>();
            builder.Services.AddTransient<UnidadMedidaGridViewModel>();
            builder.Services.AddTransient<HabilidadGridViewModel>();
            builder.Services.AddTransient<DivipolaGridViewModel>();
            builder.Services.AddTransient<ConceptoCalificacionGridViewModel>();


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
