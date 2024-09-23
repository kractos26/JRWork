
using System.Runtime.Serialization;

namespace JWork.UI.Administracion.Common;
/// <summary>
/// Excepción personalizada para el sistema JWork.
/// </summary>
[Serializable]
public class JWorkException : Exception
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="JWorkException"/>.
    /// </summary>
    public JWorkException()
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="JWorkException"/> con un mensaje de error especificado.
    /// </summary>
    /// <param name="message">El mensaje que describe el error.</param>
    public JWorkException(string? message) : base(message)
    {
    }

}
