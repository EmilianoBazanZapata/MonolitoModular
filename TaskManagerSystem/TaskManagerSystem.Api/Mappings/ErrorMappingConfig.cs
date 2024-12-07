using System.Net;
using Mapster;
using TaskManagerSystem.Api.Models;

namespace TaskManagerSystem.Api.Mappings;

public class ErrorMappingConfig : IMapsterConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Exception, ErrorResponse>()
            .Map(dest => dest.StatusCode, src => GetStatusCode(src))
            .Map(dest => dest.ErrorType, src => src.GetType().Name)
            .Map(dest => dest.Message, src => src.Message)
            .Map(dest => dest.Timestamp, src => DateTime.UtcNow);
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            ArgumentNullException or ArgumentException => (int)HttpStatusCode.BadRequest,
            InvalidOperationException => (int)HttpStatusCode.Conflict,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }
}