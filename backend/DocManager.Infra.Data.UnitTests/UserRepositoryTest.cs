using DocManager.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DocManager.Infra.Data.UnitTests;

[TestClass]
public class UserRepositoryTest
{
    private readonly Mock<IDbContextFactory<ApplicationDbContext>> _dbContextFactory;

    public UserRepositoryTest()
    {
        _dbContextFactory = new Mock<IDbContextFactory<ApplicationDbContext>>();
    }
    private ApplicationDbContext CreateDbContext()
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        return new ApplicationDbContext(builder.Options);
    }
    
    
    [TestMethod]
    public async Task CreateUser()
    {
        // Arrange
        var username = "junioressono";
        var password = "1234";
        var isAdmin = true;
        var dbContext = CreateDbContext();
        _dbContextFactory.Setup((factory => factory.CreateDbContext())).Returns(dbContext);
        var userRepository = new UserRepository(_dbContextFactory.Object);
        
        // Acts
        var user = await userRepository.CreateUserAsync(username, password, isAdmin);
        
        // Asserts
        var dbUser =
            dbContext.Users.Single(u => u.Username == username && u.Password == password && u.IsAdmin == isAdmin);
        Assert.IsNotNull(dbUser);

    }
}