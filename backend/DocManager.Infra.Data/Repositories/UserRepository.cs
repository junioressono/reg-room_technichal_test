using DocManager.Core.Domain.Entities;
using DocManager.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Infra.Data.Repositories;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(IDbContextFactory<ApplicationDbContext> dbContext)
    {
        _dbContext = dbContext.CreateDbContext();
    }
    
    public async Task<User> CreateUserAsync(string username, string password, bool isAdmin, CancellationToken cancellationToken = default)
    {
        var newUser = new User
        {
            Username = username,
            Password = password,
            IsAdmin = isAdmin,
            CreatedAt = DateTime.Now
        };
        await _dbContext.Users.AddAsync(newUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newUser;
    }

    public async Task<User?> GetUserByUsernameAndPasswordAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password, cancellationToken);
    }

    public async Task<IList<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        if (user == null)
            return;
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}