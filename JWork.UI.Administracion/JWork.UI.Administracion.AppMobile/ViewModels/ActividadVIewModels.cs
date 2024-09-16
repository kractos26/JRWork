using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class ActividadVIewModels : BindingUtilObject
    {

        private ActividadDto _area;
        public ActividadVIewModels()
        {
            _area = new();
            Oficios = [];//Data llega del business
            OficioSeleccionado = new();//Data llega del business
            PropertyChanged += _bindingUtil_PropertyChanged;
        }

        private void _bindingUtil_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OficioSeleccionado))
            {
                _area.OficioId = OficioSeleccionado.OficioId;

            }
        }

        public int ActividadId
        {
            get { return _area.ActividadId; }
            set
            {
                if (_area.ActividadId != value)
                {
                    _area.ActividadId = value;
                    RaisePropertyChanged(nameof(ActividadId));
                }
            }
        }

        public string? Nombre
        {
            get { return _area.Nombre; }
            set
            {
                if (_area.Nombre != value)
                {
                    _area.Nombre = value;
                    RaisePropertyChanged(nameof(Nombre));
                }
            }
        }

        public int OficioId
        {
            get
            {
                return _area.OficioId;
            }
            set
            {
                if( _area.OficioId != value)
                {
                    _area.OficioId= value;
                    RaisePropertyChanged(nameof(OficioId));
                }
            }
        }

        private ObservableCollection<OficioDto>? _oficios;

        public ObservableCollection<OficioDto>? Oficios
        {
            get { return _oficios; }
            set
            {

                if (_oficios != value)
                {
                    _oficios = value;
                    RaisePropertyChanged();
                }
            }
        }

        private OficioDto _oficioSeleccionado;

        public OficioDto OficioSeleccionado
        {
            get { return _oficioSeleccionado; }
            set
            {
                if (_oficioSeleccionado != value)
                {
                    _oficioSeleccionado = value;
                    RaisePropertyChanged();
                }

            }
        }


    }
}
