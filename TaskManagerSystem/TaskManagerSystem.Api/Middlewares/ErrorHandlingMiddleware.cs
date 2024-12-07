using System.Text.Json;
using Mapster;
using TaskManagerSystem.Api.Models;

namespace TaskManagerSystem.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Usar Mapster para mapear la excepción a ErrorResponse
        var errorResponse = exception.Adapt<ErrorResponse>();
        errorResponse.TraceId = context.TraceIdentifier;

        // Configurar el estado HTTP según el código del modelo
        context.Response.StatusCode = errorResponse.StatusCode;
        context.Response.ContentType = "application/json";

        // Serializar y devolver la respuesta
        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}