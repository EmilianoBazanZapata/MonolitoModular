using MediatR;

namespace Modules.WorkManagement.Application.Features.Common;

public abstract class BaseCommand<TResponse> : IRequest<TResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}