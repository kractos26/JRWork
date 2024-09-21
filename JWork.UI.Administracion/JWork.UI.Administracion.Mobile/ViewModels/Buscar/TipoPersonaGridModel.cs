using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;
using JWork.UI.Administracion.Mobile.Service;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class TipoPersonaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<TipoPersonaDto> tipopersonas;

        [ObservableProperty]
        public TipoPersonaDto tipopersonaselecionada;

        [ObservableProperty]
        public string? mensaje;

        private readonly TipoPersonaBL _tipopersonaBL;
        private readonly INavigationService _navigationService;
        public TipoPersonaGridViewModel(TipoPersonaBL habilidadBL,INavigationService navigationService)
        {
            _tipopersonaBL = habilidadBL;
            tipopersonas = [];
            _navigationService = navigationService;
            tipopersonaselecionada = new();
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
            try
            {
                List<TipoPersonaDto> resp = await _tipopersonaBL.Buscar(new Common.PaginadoRequest<TipoPersonaDto>() { 
                TotalRegistros = 20,
                NumeroPagina =1
                });
                if (resp != null)
                {
                    tipopersonas = new ObservableCollection<TipoPersonaDto>(resp);

                }
            }
            catch (Exception ex)
            {
                mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
