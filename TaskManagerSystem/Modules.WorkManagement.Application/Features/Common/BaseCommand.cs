using MediatR;

namespace Modules.WorkManagement.Application.Features.Common;

public abstract class BaseCommand<TResponse> : IRequest<TResponse>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
}