using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class OficioGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<OficioDto> oficios;

        [ObservableProperty]
        public OficioDto oficioseleccionado;

        private readonly OficioBL _habilidadBL;
        public OficioGridViewModel(OficioBL habilidadBL)
        {
            _habilidadBL = habilidadBL;
            oficioseleccionado = new ();
            oficios = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(oficioseleccionado))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<OficioDto>> resp = await _habilidadBL.Buscar(new OficioDto() { });
            if (resp.Entidad != null) 
            {
                oficios = new ObservableCollection<OficioDto>(resp.Entidad);

            }
        }
    }
}
