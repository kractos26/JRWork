using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class DivipolaViewModel : ViewModelGlobal
    {
        private readonly DivipolaDto _divipolaDto;
        public DivipolaViewModel()
        {
            _divipolaDto = new DivipolaDto();
        }

        [ObservableProperty]
        public int divipolaId;



        [ObservableProperty]

        public decimal codigo;


        [ObservableProperty]
        public string nombre;


        [ObservableProperty]
        public decimal? codigoPadre;



    }
}
