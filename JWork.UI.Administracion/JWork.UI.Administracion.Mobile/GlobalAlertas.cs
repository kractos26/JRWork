using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Plugin.LocalNotification.iOSOption;

namespace JWork.UI.Administracion.Mobile;

public class GlobalAlertas
{
    public static async Task Error(string mensaje)
    {
        var notification = new NotificationRequest
        {
            NotificationId = 100,
            Title = "Error", // Cambiado a "Error"
            Description = mensaje, // Aquí puedes pasar un mensaje de error personalizado

            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(30) // Programada para 30 segundos después
            },

            Android = new AndroidOptions
            {
               
            },

            
        };

        await LocalNotificationCenter.Current.Show(notification);

    }
}
