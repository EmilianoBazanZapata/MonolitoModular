namespace Modules.User.Users.Abstractions;

public interface IUserDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}