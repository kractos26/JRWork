using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;
using JWork.UI.Administracion.Mobile.Service;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class UnidadMedidaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<UnidadMedidaDto> unidadmedida;

        [ObservableProperty]
        public UnidadMedidaDto unidadmedidaselecionada;

        [ObservableProperty]
        public string? mensaje;
        private readonly UnidadMedidaBL _unidadmedidaBL;
        private readonly INavigationService _navigationService;
        public UnidadMedidaGridViewModel(UnidadMedidaBL unidadmedidaBL, INavigationService navigationService)
        {
            _unidadmedidaBL = unidadmedidaBL;
            unidadmedida = [];
            _navigationService = navigationService;
            unidadmedidaselecionada = new();
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Unidadmedidaselecionada))
            {
                string uri = $"{nameof(UnidadMedidaPage)}?id={Unidadmedidaselecionada.UnidadMedidaId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {

               List<UnidadMedidaDto> resp = await _unidadmedidaBL.Buscar(new Common.PaginadoRequest<UnidadMedidaDto>() { 
                   Entidad = new(),
                TotalRegistros = 20,
                NumeroPagina = 1
               });
                if (resp != null)
                {
                    Unidadmedida = new ObservableCollection<UnidadMedidaDto>(resp);

                }
            }
            catch (Exception ex)
            {
                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
