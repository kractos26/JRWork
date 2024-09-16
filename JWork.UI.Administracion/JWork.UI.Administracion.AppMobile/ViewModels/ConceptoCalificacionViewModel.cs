using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class ConceptoCalificacionViewModel : BindingUtilObject
    {
        private readonly ConceptoCalificacionDto _conCalificacion;
        public ConceptoCalificacionViewModel()
        {
            _conCalificacion = new ConceptoCalificacionDto();
        }

        public int ConceptoCalificacionId
        {
            get { return _conCalificacion.ConceptoCalificacionId; }
            set
            {
                if (_conCalificacion.ConceptoCalificacionId != value)
                {
                    _conCalificacion.ConceptoCalificacionId = value;
                    RaisePropertyChanged(nameof(ConceptoCalificacionId));
                }
            }
        }

        public string? Nombre
        {
            get
            {
                return _conCalificacion.Nombre;
            }
            set
            {
                if (_conCalificacion.Nombre != value)
                {
                    _conCalificacion.Nombre = value;
                    RaisePropertyChanged(nameof(Nombre));
                }
            }
        }

        public string? Descripcion
        {
            get
            {
                return _conCalificacion.Descripcion;
            }
            set { 
                if(_conCalificacion.Descripcion != value)
                {
                    RaisePropertyChanged(nameof(Descripcion));
                }
            }
        }
    }
}
