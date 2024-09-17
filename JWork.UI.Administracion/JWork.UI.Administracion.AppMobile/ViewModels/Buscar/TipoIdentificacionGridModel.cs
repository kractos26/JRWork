using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class TipoIdentificacionGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<TipoIdentificacionDto> tipoidentificaciones;

        [ObservableProperty]
        public TipoIdentificacionDto tipoidentificacionselecionada;

        private readonly TipoIdentificacionBL _tipoidentificacionesBL;
        public TipoIdentificacionGridViewModel(TipoIdentificacionBL tipoidentificacionesBL)
        {
            _tipoidentificacionesBL = tipoidentificacionesBL;
            tipoidentificacionselecionada = new ();
            tipoidentificaciones = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tipoidentificacionselecionada))
            { 
                
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<TipoIdentificacionDto>> resp = await _tipoidentificacionesBL.Buscar(new TipoIdentificacionDto() { });
            if (resp.Entidad != null) 
            {
                tipoidentificaciones = new ObservableCollection<TipoIdentificacionDto>(resp.Entidad);

            }
        }
    }
}
