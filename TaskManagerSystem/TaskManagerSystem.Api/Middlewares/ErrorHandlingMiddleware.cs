using System.Text.Json;
using Mapster;
using TaskManagerSystem.Application.ViewModels.Response;
using TaskManagerSystem.Core.Exceptions;

namespace TaskManagerSystem.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (BaseAppException ex) // Manejar excepciones personalizadas
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex) // Manejar excepciones generales
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        // Usar Mapster para mapear la excepción a un ErrorResponse
        var errorResponse = exception.Adapt<ErrorResponse>();

        context.Response.StatusCode = errorResponse.StatusCode; // Establecer el código de estado HTTP

        // Serializar y enviar el objeto de respuesta
        var json = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(json);
    }


}