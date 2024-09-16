using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class UnidadMedidaViewModel : BindingUtilObject
    {
        private readonly UnidadMedidaDto _unidadMedida;
        public UnidadMedidaViewModel()
        {
            _unidadMedida = new UnidadMedidaDto();
        }

        public int UnidadMedidaId
        {
            get
            {
                return _unidadMedida.UnidadMedidaId;
            }
            set
            {
                if (_unidadMedida.UnidadMedidaId != value)
                {
                    _unidadMedida.UnidadMedidaId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string? Nombre
        {
            get { return _unidadMedida.Nombre; }
            set
            {
                if (_unidadMedida.Nombre != value)
                {
                    _unidadMedida.Nombre = value; 
                    RaisePropertyChanged();
                }
            }
        }
    }
}
