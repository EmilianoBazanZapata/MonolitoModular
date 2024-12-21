using System.Text.Json;
using Mapster;
using Microsoft.AspNetCore.Http;
using Modules.Shared.Entities;
using TaskManager.Shared.Core.Exceptions;

namespace TaskManager.Shared.Core.Middlewares;

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
        
        var errorResponse = exception.Adapt<ErrorResponse>();
        
        var json = JsonSerializer.Serialize(errorResponse);
        
        await context.Response.WriteAsync(json);
    }
}