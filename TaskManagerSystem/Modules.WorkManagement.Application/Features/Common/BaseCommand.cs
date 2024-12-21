using MediatR;

namespace Modules.WorkManagement.Application.Features.Common;

public abstract record BaseCommand<TResponse> : IRequest<TResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}