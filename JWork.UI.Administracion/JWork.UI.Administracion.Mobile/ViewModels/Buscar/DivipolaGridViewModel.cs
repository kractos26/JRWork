using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class DivipolaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<DivipolaDto> divipolas;

        [ObservableProperty]
        public DivipolaDto divipolalecionada;

        [ObservableProperty]
        public string? mensaje;

        private readonly DivipolaBL _divipolaBL;
        private readonly INavigationService _navigationService;
        public DivipolaGridViewModel(DivipolaBL divipolaBL,
            INavigationService navigation)
        {
            _divipolaBL = divipolaBL;
            _navigationService = navigation;
            divipolas = [];
            divipolalecionada = new();
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Divipolalecionada))
            {
                string uri = $"{nameof(DivipolaPage)}?id={Divipolalecionada.DivipolaId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<DivipolaDto> resp = await _divipolaBL.Buscar(new()
                {
                    Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1
                });
                if (resp.Any())
                {
                    Divipolas = new ObservableCollection<DivipolaDto>(resp);

                }
            }
            catch (Exception ex)
            {
                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
