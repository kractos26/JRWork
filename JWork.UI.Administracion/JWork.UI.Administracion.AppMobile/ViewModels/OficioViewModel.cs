using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class OficioViewModel : ViewModelGlobal
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

        [ObservableProperty]
        public int oficioId;

        [ObservableProperty]
        public string oficioName;

        [ObservableProperty]
        public int areaId;

        [ObservableProperty]
        private ObservableCollection<AreaDto> areas;


        [ObservableProperty]
        private AreaDto areaSeleccionada;

        


    }
}
