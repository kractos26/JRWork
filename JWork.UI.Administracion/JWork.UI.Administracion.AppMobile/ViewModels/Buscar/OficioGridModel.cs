using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class OficioGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<OficioDto> oficios;

        [ObservableProperty]
        public OficioDto oficioseleccionado;

        private readonly OficioBL _habilidadBL;
        private readonly INavigationService _navigationService;
        public OficioGridViewModel(OficioBL habilidadBL,INavigationService navigationService)
        {
            _habilidadBL = habilidadBL;
            _navigationService = navigationService;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(oficioseleccionado))
            {
                string uri = $"{nameof(OficioPage)}?id={oficioseleccionado.OficioId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<OficioDto>> resp = await _habilidadBL.Buscar(new OficioDto() { });
            if (resp.Entidad != null) 
            {
                oficios = new ObservableCollection<OficioDto>(resp.Entidad);

            }
        }
    }
}
