using Mapster;
using TaskManagerSystem.Application.Interfaces;
using TaskManagerSystem.Application.ViewModels.Response;

namespace TaskManagerSystem.Application.Mappings;

public class ErrorMappingConfig : IMapsterConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Exception, ErrorResponse>()
            .Map(dest => dest.ErrorType, src => src.GetType().Name)
            .Map(dest => dest.Message, src => src.Message)
            .Map(dest => dest.Timestamp, src => DateTime.UtcNow);
    }
}