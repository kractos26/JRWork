using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Mobile.Views.Buscar;

namespace JWork.UI.Administracion.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ActividadPage), typeof(ActividadPage));
            Routing.RegisterRoute(nameof(AreaPopup), typeof(AreaPopup));
            Routing.RegisterRoute(nameof(ConceptoCalificacionPage), typeof(ConceptoCalificacionPage));
            Routing.RegisterRoute(nameof(DivipolaPage), typeof(DivipolaPage));
            Routing.RegisterRoute(nameof(OficioPopup), typeof(OficioPopup));
            Routing.RegisterRoute(nameof(TipoDocumentoPage), typeof(TipoDocumentoPage));
            Routing.RegisterRoute(nameof(TipoPersonaPage), typeof(TipoPersonaPage));
            Routing.RegisterRoute(nameof(UnidadMedidaPage), typeof(UnidadMedidaPage));
            Routing.RegisterRoute(nameof(TipoIdentificacionPage), typeof(TipoIdentificacionPage));
            Routing.RegisterRoute(nameof(AreasPage), typeof(AreasPage));

        }
    }
}
