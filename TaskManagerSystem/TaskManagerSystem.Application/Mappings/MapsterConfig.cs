using Mapster;
using TaskManagerSystem.Application.Interfaces;

namespace TaskManagerSystem.Application.Mappings;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        var config = TypeAdapterConfig.GlobalSettings;

        // Registrar configuraciones específicas
        RegisterMapping(new ErrorMappingConfig(), config);

        // Aquí se pueden agregar más configuraciones en el futuro
        // RegisterMapping(new TaskMappingConfig(), config);
        // RegisterMapping(new ProjectMappingConfig(), config);
    }

    private static void RegisterMapping(IMapsterConfiguration configuration, TypeAdapterConfig config)
    {
        configuration.Register(config);
    }
}