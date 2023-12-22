using DocManager.Core.Domain.Entities;

namespace DocManager.Core.Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(string username, string password, bool isAdmin, CancellationToken cancellationToken = default);
    Task<User> GetUserAsync(string username, string password, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(string username, CancellationToken cancellationToken = default);
}