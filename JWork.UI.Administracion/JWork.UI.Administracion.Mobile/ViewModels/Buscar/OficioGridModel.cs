using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;
using JWork.UI.Administracion.Mobile.Service;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class OficioGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<OficioDto> oficios;

        [ObservableProperty]
        public OficioDto oficioseleccionado;

        [ObservableProperty]
        public string? mensaje;
        private readonly OficioBL _habilidadBL;


        private readonly INavigationService _navigationService;
        public OficioGridViewModel(OficioBL habilidadBL,INavigationService navigationService)
        {
            _habilidadBL = habilidadBL;
            oficios = [];
            _navigationService = navigationService;
            oficioseleccionado = new();
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
            try
            {
                List<OficioDto> resp = await _habilidadBL.Buscar(new () { });
                if (resp.Any())
                {
                    oficios = new ObservableCollection<OficioDto>(resp);

                }
            }
            catch (Exception ex)
            {

                mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
