using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.ViewModels;
using JWork.UI.Administracion.AppMobile.Views;
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

            return builder.Build();
        }
    }
}
