using Mapster;

namespace TaskManagerSystem.Application.Interfaces;

public interface IMapsterConfiguration
{
    void Register(TypeAdapterConfig config);
}