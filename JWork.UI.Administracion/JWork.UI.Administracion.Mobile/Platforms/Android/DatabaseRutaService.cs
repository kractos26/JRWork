using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using JWork.UI.Administracion.Common;
using A = Android;

namespace JWork.UI.Administracion.Mobile.Platforms.Android;

public class DatabaseRutaService : IDatabaseRutaService
{
    // Método para ajustar permisos
    public void AjustePermisos(string archivo, object actividad)
    {
        try
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                // Verifica permisos de escritura
                if (ContextCompat.CheckSelfPermission(A.App.Application.Context, A.Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
                {
                    var activid = (Activity)actividad;
                    ActivityCompat.RequestPermissions(activid, new string[] { A.Manifest.Permission.WriteExternalStorage }, 0);
                }
            }

            // Si el archivo existe, ajustar sus atributos
            if (File.Exists(archivo))
            {
                File.SetAttributes(archivo, FileAttributes.Normal);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error ajustando permisos del archivo: {ex.Message}");
        }
    }

    // Método para obtener la ruta de un archivo específico
    public string GetRuta(string nombrearchivo)
    {
        return Path.Combine(FileSystem.AppDataDirectory, nombrearchivo);
    }

    // Método para obtener la ruta del directorio de datos de la aplicación
    public string GetRuta()
    {
        return FileSystem.AppDataDirectory;
    }

    // Método para solicitar permisos de lectura y escritura en el almacenamiento externo
    public Task SolicitarPermisos(object activity)
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
        {
            // Verificar si los permisos ya están concedidos
            bool permisosConcedidos = ContextCompat.CheckSelfPermission(A.App.Application.Context, A.Manifest.Permission.WriteExternalStorage) ==
               Permission.Granted
               && ContextCompat.CheckSelfPermission(A.App.Application.Context, A.Manifest.Permission.ReadExternalStorage) ==
               Permission.Granted;

            // Si no están concedidos, solicitarlos
            if (!permisosConcedidos)
            {
                string[] permisos = {
                    A.Manifest.Permission.ReadExternalStorage,
                    A.Manifest.Permission.WriteExternalStorage
                };

                ActivityCompat.RequestPermissions((Activity)activity, permisos, 0);
            }
        }

        return Task.CompletedTask;
    }
}
