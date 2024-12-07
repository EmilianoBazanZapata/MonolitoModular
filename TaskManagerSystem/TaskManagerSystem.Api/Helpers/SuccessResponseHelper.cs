using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Application.ViewModels.Response;

namespace TaskManagerSystem.Api.Helpers;

public static class SuccessResponseHelper
{
    public static IActionResult CreateResponse<T>(T data, string message = "Request processed successfully.")
    {
        var statusCode = InferStatusCode(data);

        var response = new SuccessResponse<T>
        {
            StatusCode = statusCode,
            Message = message,
            Data = data
        };

        return new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }

    private static int InferStatusCode<T>(T data)
    {
        // Inferir código de estado según convenciones
        if (data == null)
            return StatusCodes.Status204NoContent; // No hay contenido

        if (typeof(T).Name.Contains("Created") || typeof(T).Name.Contains("Add"))
            return StatusCodes.Status201Created; // Creación exitosa

        return StatusCodes.Status200OK; // Respuesta general exitosa
    }
}