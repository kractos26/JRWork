using CommunityToolkit.Mvvm.ComponentModel;
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
        public TipoDocumentoGridViewModel(TipoDocumentoBL tipodocumentoBL)
        {
            _tipodocumentoBL = tipodocumentoBL;
            tipodocumentoselecionada = new ();
            tipodocumento = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tipodocumentoselecionada))
            { 
                
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
