using JWork.UI.Administracion.DataBase;

namespace JWork.UI.Administracion.Mobile;

public class DatabaseRutaService : IDatabaseRutaService
{
    public string GetRuta(string nombrearchivo)
    {
        string ruta = FileSystem.AppDataDirectory;
        return Path.Combine(ruta, nombrearchivo);
    }
}

