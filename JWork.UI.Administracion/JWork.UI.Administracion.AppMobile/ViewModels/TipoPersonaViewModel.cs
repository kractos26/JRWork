using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class TipoPersonaViewModel : BindingUtilObject
    {
        private readonly TipoPersonaDto _tipopersonaDto;
        public TipoPersonaViewModel()
        {
            _tipopersonaDto = new TipoPersonaDto();
        }

        public int TipoPersonaId
        {
            get { return _tipopersonaDto.TipoPersonaId; }
            set
            {
                if (_tipopersonaDto.TipoPersonaId != value)
                {
                    _tipopersonaDto.TipoPersonaId = value;
                    RaisePropertyChanged(nameof(TipoPersonaId));
                }
            }
        }

        public string Nombre
        {
            get
            {
                return _tipopersonaDto.Nombre;
            }
            set
            {
                if (_tipopersonaDto.Nombre != value)
                {
                    _tipopersonaDto.Nombre = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
