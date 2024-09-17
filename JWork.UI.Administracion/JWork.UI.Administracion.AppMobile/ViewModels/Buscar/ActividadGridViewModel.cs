using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class ActividadGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<ActividadDto> actividades;

        [ObservableProperty]
        public ActividadDto actividadselecionada;

        private readonly ActividadBL _actividadBL;
        public  ActividadGridViewModel(ActividadBL actividadBL)
        {
            _actividadBL = actividadBL;
            actividadselecionada = new ActividadDto();
            actividades = [];
            PropertyChanged += ActividadGridViewModel_PropertyChanged;
        }

        private void ActividadGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(actividadselecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<ActividadDto>> resp = await _actividadBL.Buscar(new ActividadDto() { });
            if (resp.Entidad != null) 
            {
                actividades = new ObservableCollection<ActividadDto>(resp.Entidad);

            }
        }
    }
}
