using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
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
        private readonly INavigationService _navigationService;
        public DivipolaGridViewModel(DivipolaBL divipolaBL,
            INavigationService navigation)
        {
            _divipolaBL = divipolaBL;
            _navigationService = navigation;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(divipolalecionada))
            {
                string uri = $"{nameof(DivipolaPage)}?id={divipolalecionada.DivipolaId}";
                await _navigationService.GotoAsync(uri);
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
