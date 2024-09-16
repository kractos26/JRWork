using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class TipoIdentificacionViewModel : ViewModelGlobal
    {
        TipoIdentificacionDto _tipoIdentificacionDto;
        public TipoIdentificacionViewModel()
        {
            _tipoIdentificacionDto = new TipoIdentificacionDto();
        }

        [ObservableProperty]
        public int tipoIdentificacionId;
        
        [ObservableProperty]
        public string sigla;
        
        [ObservableProperty]
        public string nombre;
        
    }
}
