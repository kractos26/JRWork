using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class AreasPage : ContentPage
{
    private readonly AreaGridViewModel _model;

    public AreasPage(AreaGridViewModel model)
	{
        _model = model;
        BindingContext = _model;
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        
        await _model.ObtenerData();
    }

   
}