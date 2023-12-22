using DocManager.Core.Domain.Entities;

namespace DocManager.Core.Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(string username, string password, bool isAdmin, CancellationToken cancellationToken = default);
    Task<User?> GetUserByUsernameAndPasswordAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<IList<User>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
}