using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class HabilidadViewModel : ViewModelGlobal
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

        [ObservableProperty]
        public int habilidadId;


        [ObservableProperty]
        public string nombre;


        [ObservableProperty]
        public int actividadId;

        [ObservableProperty]
        private ObservableCollection<ActividadDto> actividades;


        [ObservableProperty]
        private ActividadDto actividadSeleccionada;

    }
}
