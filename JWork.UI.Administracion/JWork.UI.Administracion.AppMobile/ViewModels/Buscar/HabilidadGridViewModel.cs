using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class HabilidadGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<HabilidadDto> areas;

        [ObservableProperty]
        public HabilidadDto habilidadlecionada;

        private readonly HabilidadBL _habilidadBL;
        public HabilidadGridViewModel(HabilidadBL habilidadBL)
        {
            _habilidadBL = habilidadBL;
            habilidadlecionada = new ();
            areas = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(habilidadlecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<HabilidadDto>> resp = await _habilidadBL.Buscar(new HabilidadDto() { });
            if (resp.Entidad != null) 
            {
                areas = new ObservableCollection<HabilidadDto>(resp.Entidad);

            }
        }
    }
}
