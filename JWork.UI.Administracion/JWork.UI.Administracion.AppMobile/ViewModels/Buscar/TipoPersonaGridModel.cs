using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class TipoPersonaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<TipoPersonaDto> tipopersona;

        [ObservableProperty]
        public TipoPersonaDto tipopersonaselecionada;

        private readonly TipoPersonaBL _tipopersonaBL;
        public TipoPersonaGridViewModel(TipoPersonaBL habilidadBL)
        {
            _tipopersonaBL = habilidadBL;
            tipopersonaselecionada = new ();
            tipopersona = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tipopersonaselecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<TipoPersonaDto>> resp = await _tipopersonaBL.Buscar(new TipoPersonaDto() { });
            if (resp.Entidad != null) 
            {
                tipopersona = new ObservableCollection<TipoPersonaDto>(resp.Entidad);

            }
        }
    }
}
