﻿using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class TipoDocumentoViewModel : ViewModelGlobal, IQueryAttributable
    {
        [ObservableProperty]
        public int tipoDocumentoId;

        [ObservableProperty]
        public string nombre;

        private readonly TipoDocumentoBL _tipodocumentoBL;
        public TipoDocumentoViewModel(TipoDocumentoBL tipoDocumentoBL)
        {
            _tipodocumentoBL = tipoDocumentoBL;
            nombre = string.Empty;
        }



        public async Task InicializarAsync()
        {
            if (tipoDocumentoId <= 0)
            {
                return;
            }

            try
            {
                var response = await _tipodocumentoBL.GetPorIdAsync(tipoDocumentoId);

                // Validar la respuesta
                if (response != null)
                {
                    nombre = response.Nombre;
                }
                
            }
            catch (Exception ex)
            {

                await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");

            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
            {
                tipoDocumentoId = id;
            }
        }

        private Task MostrarError(string mensaje)
        {
            return Task.CompletedTask;
        }
    }
}
