using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
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
        private readonly INavigationService _navigationService;
        public HabilidadGridViewModel(HabilidadBL habilidadBL,INavigationService navigationService)
        {
            _habilidadBL = habilidadBL;
            _navigationService = navigationService;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(habilidadlecionada))
            {
                string uri = $"{nameof(HabilidadPage)}?id={habilidadlecionada.HabilidadId}";
                await _navigationService.GotoAsync(uri);
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
