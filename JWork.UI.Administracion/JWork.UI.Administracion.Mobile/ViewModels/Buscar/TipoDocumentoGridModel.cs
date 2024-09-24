using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class TipoDocumentoGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<TipoDocumentoDto> tipodocumentos;

        [ObservableProperty]
        public TipoDocumentoDto tipodocumentoselecionada;

        [ObservableProperty]
        public string? mensaje;

        private readonly TipoDocumentoBL _tipodocumentoBL;
        private readonly INavigationService _navigationService;
        public TipoDocumentoGridViewModel(TipoDocumentoBL tipodocumentoBL, INavigationService navigationService)
        {
            _tipodocumentoBL = tipodocumentoBL;
            _navigationService = navigationService;
            tipodocumentos = [];
            tipodocumentoselecionada = new();
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tipodocumentoselecionada))
            {
                string uri = $"{nameof(TipoDocumentoPage)}?id={Tipodocumentoselecionada.TipoDocumentoId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                var resp = await _tipodocumentoBL.Buscar(new()
                {
                    Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1
                });

                if (resp != null)
                {
                    Tipodocumentos = new(resp);

                }
            }
            catch (Exception ex)
            {
                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
