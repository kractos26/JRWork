﻿using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class UnidadMedidaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<UnidadMedidaDto> unidadmedida;

        [ObservableProperty]
        public UnidadMedidaDto unidadmedidaselecionada;

        [ObservableProperty]
        public string? mensaje;
        private readonly UnidadMedidaBL _unidadmedidaBL;
        private readonly INavigationService _navigationService;
        public UnidadMedidaGridViewModel(UnidadMedidaBL unidadmedidaBL, INavigationService navigationService)
        {
            _unidadmedidaBL = unidadmedidaBL;
            unidadmedida = [];
            _navigationService = navigationService;
            unidadmedidaselecionada = new();
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(unidadmedidaselecionada))
            {
                string uri = $"{nameof(UnidadMedidaPage)}?id={unidadmedidaselecionada.UnidadMedidaId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {

               List<UnidadMedidaDto> resp = await _unidadmedidaBL.Buscar(new Common.PaginadoRequest<UnidadMedidaDto>() { 
                TotalRegistros = 20,
                NumeroPagina = 1
               });
                if (resp != null)
                {
                    unidadmedida = new ObservableCollection<UnidadMedidaDto>(resp);

                }
            }
            catch (Exception ex)
            {
                mensaje = $"ocurrio un error {ex.Message}";
            }
        }
    }
}
