using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class UnidadMedidaViewModel : ViewModelGlobal
    {
        private readonly UnidadMedidaDto _unidadMedida;
        public UnidadMedidaViewModel()
        {
            _unidadMedida = new UnidadMedidaDto();
        }

        [ObservableProperty]
        public int unidadMedidaId;
        

        [ObservableProperty]
        public string? nombre;
        
    }
}
