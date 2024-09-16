using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class TipoIdentificacionViewModel : BindingUtilObject
    {
        TipoIdentificacionDto _tipoIdentificacionDto;
        public TipoIdentificacionViewModel()
        {
            _tipoIdentificacionDto = new TipoIdentificacionDto();
        }

        public int TipoIdentificacionId
        {
            get { return _tipoIdentificacionDto.TipoIdentificacionId; }
            set
            {
                if (_tipoIdentificacionDto.TipoIdentificacionId != value)
                {
                    _tipoIdentificacionDto.TipoIdentificacionId = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Sigla
        {
            get { return _tipoIdentificacionDto.Sigla; }
            set
            {
                if (_tipoIdentificacionDto.Sigla != value)
                {
                    _tipoIdentificacionDto.Sigla = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Nombre
        {
            get { return _tipoIdentificacionDto.Nombre; }
            set
            {
                if(_tipoIdentificacionDto.Nombre != value)
                {
                    _tipoIdentificacionDto.Nombre = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
