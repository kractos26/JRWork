using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class TipoDocumentoViewModel : BindingUtilObject
    {
        TipoDocumentoDto _tipodocumentodto;
        public TipoDocumentoViewModel()
        {
            _tipodocumentodto = new TipoDocumentoDto();
        }

        public int TipoDocumentoId
        {
            get { return _tipodocumentodto.TipoDocumentoId; }
            set
            {
                if (_tipodocumentodto.TipoDocumentoId != value)
                {
                    _tipodocumentodto.TipoDocumentoId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Nombre
        {
            get
            {
                return _tipodocumentodto.Nombre;
            }
            set
            {
                if (_tipodocumentodto.Nombre != value)
                {
                    _tipodocumentodto.Nombre = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
