﻿using JWork.UI.Administracion.AppMobile.Views;

namespace JWork.UI.Administracion.AppMobile
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
            Routing.RegisterRoute(nameof(OficioPage), typeof(OficioPage));
            Routing.RegisterRoute(nameof(TipoDocumentoPage), typeof(TipoDocumentoPage));
            Routing.RegisterRoute(nameof(TipoPersonaPage), typeof(TipoPersonaPage));
            Routing.RegisterRoute(nameof(UnidadMedidaPage), typeof(UnidadMedidaPage));
            Routing.RegisterRoute(nameof(TipoIdentificacionPage), typeof(TipoIdentificacionPage));

        }
    }
}
