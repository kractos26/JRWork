using Serilog;
using System.Net;
using System.Text.Json;

namespace JWork.Administracion.WebApi
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        } 

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Logea el error con Serilog
            Log.Error(exception, "An error occurred");

            // Configuración de respuesta HTTP
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Serializa el resultado en formato JSON para la respuesta
            var result = JsonSerializer.Serialize(new { error = exception.Message });

            // Retorna la respuesta escrita en el cuerpo
            return context.Response.WriteAsync(result);
        }
    }
}
