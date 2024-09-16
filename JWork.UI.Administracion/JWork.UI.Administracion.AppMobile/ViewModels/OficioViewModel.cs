using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public class OficioViewModel : BindingUtilObject
    {
        OficioDto _oficioDto;
        public OficioViewModel()
        {
            _oficioDto = new OficioDto();
            PropertyChanged += OficioViewModel_PropertyChanged;
        }

        private void OficioViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AreaSeleccionada))
            {
                _oficioDto.AreaId = AreaSeleccionada.AreaId;
            }
        }

        public int OficioId
        {
            get { return _oficioDto.OficioId; }
            set
            {
                if (_oficioDto.OficioId != value)
                {
                    _oficioDto.OficioId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string OficioName
        {
            get { return _oficioDto.Nombre; }
            set
            {
                if (_oficioDto.Nombre != value)
                {
                    _oficioDto.Nombre = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int AreaId
        {
            get { return _oficioDto.AreaId; }
            set
            {
                if (_oficioDto.AreaId != value)
                {
                    _oficioDto.AreaId = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<AreaDto> _areas;

        public ObservableCollection<AreaDto> Areas
        {
            get { return _areas; }
            set
            {
                if (_areas != value)
                {
                    _areas = value;
                    RaisePropertyChanged();
                }
            }
        }

        private AreaDto _areaSeleccionada;

        public AreaDto AreaSeleccionada
        {
            get { return _areaSeleccionada; }
            set { 
                if( _areaSeleccionada != value)
                {
                    _areaSeleccionada = value;
                    RaisePropertyChanged();
                }
                _areaSeleccionada = value;
            }
        }


    }
}
