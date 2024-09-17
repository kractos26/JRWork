using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class AreaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<AreaDto> areas;

        [ObservableProperty]
        public AreaDto arealecionada;

        private readonly AreaBL _areaBL;
        public  AreaGridViewModel(AreaBL areaBL)
        {
            _areaBL = areaBL;
            arealecionada = new ();
            areas = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(arealecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<AreaDto>> resp = await _areaBL.Buscar(new AreaDto() { });
            if (resp.Entidad != null) 
            {
                areas = new ObservableCollection<AreaDto>(resp.Entidad);

            }
        }
    }
}
