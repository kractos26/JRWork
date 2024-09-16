using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class TipoDocumentoViewModel : ViewModelGlobal
    {
        TipoDocumentoDto _tipodocumentodto;
        public TipoDocumentoViewModel()
        {
            _tipodocumentodto = new TipoDocumentoDto();
        }

        [ObservableProperty]
        public int tipoDocumentoId;

        [ObservableProperty]
        public string nombre;
        
    }
}
