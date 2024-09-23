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
            if (e.PropertyName == nameof(Oficioseleccionado))
            {
                string uri = $"{nameof(OficioPage)}?id={Oficioseleccionado.OficioId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<OficioDto> resp = await _habilidadBL.Buscar(new () { 
                 Entidad = new(),
                 TotalRegistros = 20,
                 NumeroPagina = 1,
                });
                if (resp.Any())
                {
                    Oficios = new ObservableCollection<OficioDto>(resp);

                }
            }
            catch (Exception ex)
            {

                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
