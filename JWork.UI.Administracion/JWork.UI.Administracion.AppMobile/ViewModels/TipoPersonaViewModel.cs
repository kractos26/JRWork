using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class TipoPersonaViewModel : ViewModelGlobal
    {
        private readonly TipoPersonaDto _tipopersonaDto;
        public TipoPersonaViewModel()
        {
            _tipopersonaDto = new TipoPersonaDto();
        }

        [ObservableProperty]
        public int tipoPersonaId;

        [ObservableProperty]
        public string nombre;
       
    }
}
