using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class DivipolaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<DivipolaDto> divipolas;

        [ObservableProperty]
        public DivipolaDto divipolalecionada;

        private readonly DivipolaBL _divipolaBL;
        public DivipolaGridViewModel(DivipolaBL divipolaBL)
        {
            _divipolaBL = divipolaBL;
            divipolalecionada = new ();
            divipolas = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(divipolalecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<DivipolaDto>> resp = await _divipolaBL.Buscar(new DivipolaDto() { });
            if (resp.Entidad != null) 
            {
                divipolas = new ObservableCollection<DivipolaDto>(resp.Entidad);

            }
        }
    }
}
