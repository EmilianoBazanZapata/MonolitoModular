using Mapster;

namespace TaskManagerSystem.Api.Mappings;

public interface IMapsterConfiguration
{
    void Register(TypeAdapterConfig config);
}