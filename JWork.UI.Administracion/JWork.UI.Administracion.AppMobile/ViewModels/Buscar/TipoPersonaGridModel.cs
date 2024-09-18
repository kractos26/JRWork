using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
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
        private readonly INavigationService _navigationService;
        public TipoPersonaGridViewModel(TipoPersonaBL habilidadBL,INavigationService navigationService)
        {
            _tipopersonaBL = habilidadBL;
            _navigationService = navigationService;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tipopersonaselecionada))
            {
                string uri = $"{nameof(TipoPersonaPage)}?id={tipopersonaselecionada.TipoPersonaId}";
                await _navigationService.GotoAsync(uri);
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
