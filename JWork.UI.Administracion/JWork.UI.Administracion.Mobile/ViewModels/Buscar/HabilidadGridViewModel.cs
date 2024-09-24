using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class HabilidadGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<HabilidadDto> areas;

        [ObservableProperty]
        public HabilidadDto habilidadlecionada;

        [ObservableProperty]
        public string? mensaje;

        private readonly HabilidadBL _habilidadBL;
        private readonly INavigationService _navigationService;
        public HabilidadGridViewModel(HabilidadBL habilidadBL, INavigationService navigationService)
        {
            _habilidadBL = habilidadBL;
            _navigationService = navigationService;
            areas = [];
            habilidadlecionada = new();
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Habilidadlecionada))
            {
                string uri = $"{nameof(HabilidadPage)}?id={Habilidadlecionada.HabilidadId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<HabilidadDto> resp = await _habilidadBL.Buscar(new()
                {
                    Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1
                });
                if (resp.Any())
                {
                    Areas = new ObservableCollection<HabilidadDto>(resp);

                }
            }
            catch (Exception ex)
            {
                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
