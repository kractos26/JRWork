using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class TipoDocumentoGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<TipoDocumentoDto> tipodocumento;

        [ObservableProperty]
        public TipoDocumentoDto tipodocumentoselecionada;

        private readonly TipoDocumentoBL _tipodocumentoBL;
        private readonly INavigationService _navigationService;
        public TipoDocumentoGridViewModel(TipoDocumentoBL tipodocumentoBL,INavigationService navigationService)
        {
            _tipodocumentoBL = tipodocumentoBL;
            _navigationService = navigationService;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tipodocumentoselecionada))
            {
                string uri = $"{nameof(TipoDocumentoPage)}?id={tipodocumentoselecionada.TipoDocumentoId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<TipoDocumentoDto>> resp = await _tipodocumentoBL.Buscar(new TipoDocumentoDto() { });
            if (resp.Entidad != null) 
            {
                tipodocumento = new ObservableCollection<TipoDocumentoDto>(resp.Entidad);

            }
        }
    }
}
