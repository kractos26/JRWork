using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class HabilidadViewModel : BindingUtilObject
    {
        private readonly HabilidadDto _habilidadDto;
        public HabilidadViewModel()
        {
            _habilidadDto = new HabilidadDto();
            PropertyChanged += HabilidadViewModel_PropertyChanged;
        }

        private void HabilidadViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ActividadSeleccionada)) { 
              _habilidadDto.ActividadId = ActividadSeleccionada.ActividadId;
            }
        }

        public int HabilidadId
        {
            get { return _habilidadDto.HabilidadId; }
            set
            {
                if (_habilidadDto.HabilidadId != value)
                {
                    _habilidadDto.HabilidadId = value;
                    RaisePropertyChanged(nameof(HabilidadId));
                }
            }
        }


        public string Nombre
        {
            get
            {
                return _habilidadDto.Nombre;
            }
            set
            {
                if (_habilidadDto.Nombre != value)
                {
                    _habilidadDto.Nombre = value;
                    RaisePropertyChanged(nameof(Nombre));
                }
            }
        }


        public int ActividadId
        {
            get { return _habilidadDto.ActividadId; }
            set
            {
                if (_habilidadDto.ActividadId != value)
                {
                    _habilidadDto.ActividadId = (int)value;
                    RaisePropertyChanged(nameof(ActividadId));
                }
            }
        }

        private ObservableCollection<ActividadDto> _actividades;

        public ObservableCollection<ActividadDto> Actividades
        {
            get { return _actividades; }
            set
            {
                if (_actividades != value)
                {
                    _actividades = value;
                    RaisePropertyChanged(nameof(Actividades));
                }
            }
        }

        private ActividadDto _actividadSeleccionada;

        public ActividadDto ActividadSeleccionada
        {
            get { return _actividadSeleccionada; }
            set
            {
                if (_actividadSeleccionada != value)
                {
                    _actividadSeleccionada = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
