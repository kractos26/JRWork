using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class DivipolaViewModel : BindingUtilObject
    {
        private readonly DivipolaDto _divipolaDto;
        public DivipolaViewModel()
        {
            _divipolaDto = new DivipolaDto();
        }

        public int DivipolaId
        {
            get { return _divipolaDto.DivipolaId; }
            set
            {
                if (_divipolaDto.DivipolaId != value)
                {
                    _divipolaDto.DivipolaId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal Codigo
        {
            get { return _divipolaDto.Codigo; }
            set
            {
                if (_divipolaDto.Codigo != value)
                {
                    _divipolaDto.Codigo = value;
                    RaisePropertyChanged();
                }

            }
        }

        public string Nombre
        {
            get { return _divipolaDto.Nombre; }
            set
            {
                if (_divipolaDto.Nombre != value)
                {
                    _divipolaDto.Nombre = value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal? CodigoPadre
        {
            get { return _divipolaDto.CodigoPadre; }
            set
            {
                if(_divipolaDto?.CodigoPadre != value && _divipolaDto?.CodigoPadre != null)
                {
                    _divipolaDto.CodigoPadre = value;
                    RaisePropertyChanged();
                }
            }
        }


    }
}
