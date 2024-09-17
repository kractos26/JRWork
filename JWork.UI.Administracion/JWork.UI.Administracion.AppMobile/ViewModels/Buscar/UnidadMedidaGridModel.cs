using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class UnidadMedidaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<UnidadMedidaDto> unidadmedida;

        [ObservableProperty]
        public UnidadMedidaDto unidadmedidaselecionada;

        private readonly UnidadMedidaBL _unidadmedidaBL;
        public UnidadMedidaGridViewModel(UnidadMedidaBL unidadmedidaBL)
        {
            _unidadmedidaBL = unidadmedidaBL;
            unidadmedidaselecionada = new ();
            unidadmedida = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(unidadmedidaselecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<UnidadMedidaDto>> resp = await _unidadmedidaBL.Buscar(new UnidadMedidaDto() { });
            if (resp.Entidad != null) 
            {
                unidadmedida = new ObservableCollection<UnidadMedidaDto>(resp.Entidad);

            }
        }
    }
}
