using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android.Content.PM;
using Android.App;
using A = Android;
using JWork.UI.Administracion.Common;


namespace JWork.UI.Administracion.Mobile.Platforms.Android;
public class DatabaseRutaService : IDatabaseRutaService
{
    public void AjustePermisos(string archivo, object actividad)
    {
        try
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                if (ContextCompat.CheckSelfPermission(A.App.Application.Context, A.Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
                {
                  var activid =  (Activity)actividad;
                    ActivityCompat.RequestPermissions(activid, [A.Manifest.Permission.WriteExternalStorage], 0);
                }
            }

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

    public string GetRuta(string nombrearchivo)
    {
        return Path.Combine(FileSystem.AppDataDirectory, nombrearchivo);

    }

    public string GetRuta()
    {
        return FileSystem.AppDataDirectory;
    }


    public Task SolicitarPermisos(object activity)
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
        {
            bool resultado = ContextCompat.CheckSelfPermission(A.App.Application.Context, A.Manifest.Permission.WriteExternalStorage) ==
               Permission.Granted
               && ContextCompat.CheckSelfPermission(A.App.Application.Context, A.Manifest.Permission.ReadExternalStorage) ==
               Permission.Granted;


            if (!resultado)
            {
                string[] permisos =
                [
                     A.Manifest.Permission.ReadExternalStorage,A.Manifest.Permission.WriteExternalStorage
                ];


                ActivityCompat.RequestPermissions((Activity)activity, permisos, 0);

            }
        }

        return Task.CompletedTask;
    }
}
