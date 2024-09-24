using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class TipoIdentificacionGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<TipoIdentificacionDto> tipoidentificaciones;

        [ObservableProperty]
        public TipoIdentificacionDto tipoidentificacionselecionada;

        [ObservableProperty]
        public string? mensaje;

        private readonly TipoIdentificacionBL _tipoidentificacionesBL;
        private readonly INavigationService _navigationService;
        public TipoIdentificacionGridViewModel(TipoIdentificacionBL tipoidentificacionesBL, INavigationService navigationService)
        {
            _tipoidentificacionesBL = tipoidentificacionesBL;
            _navigationService = navigationService;
            tipoidentificaciones = [];
            tipoidentificacionselecionada = new();
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tipoidentificacionselecionada))
            {
                string uri = $"{nameof(TipoIdentificacionPage)}?id={Tipoidentificacionselecionada.TipoIdentificacionId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<TipoIdentificacionDto> resp = await _tipoidentificacionesBL.Buscar(new Common.PaginadoRequest<TipoIdentificacionDto>()
                {
                    Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1
                });
                if (resp.Any())
                {
                    Tipoidentificaciones = new ObservableCollection<TipoIdentificacionDto>(resp);

                }
            }
            catch (Exception ex)
            {

                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
