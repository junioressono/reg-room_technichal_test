using DocManager.Core.Business.Users.AddUser;
using DocManager.Core.Domain.Entities;
using DocManager.Core.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocManager.Core.UnitTests.AddUser;

[TestClass]
public class AddUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepoMock;

    public AddUserCommandHandlerTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
    }

    [TestMethod]
    public async Task Handle_RequestUsernamePasswordNull_ThrowsException()
    {
        // Arrange
        var request = new AddUserRequest(null, null);
        var handler = new AddUserCommandHandler(_userRepoMock.Object);
        
        // Acts & Asserts
        await Assert.ThrowsExceptionAsync<ArgumentNullException>((() => handler.Handle(request, CancellationToken.None)));
    }

    [TestMethod]
    public async Task Handle_RequestUsernamePasswordDefined_CreateUser()
    {
        // Arrange
        var username = "junioressono";
        var createdAt = DateTime.Now;
        var request = new AddUserRequest(username, "1234");
        var handler = new AddUserCommandHandler(_userRepoMock.Object);
        _userRepoMock.Setup((repository =>
                repository.CreateUserAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                    CancellationToken.None)))
            .ReturnsAsync(((string username, string password, bool isAdmin, CancellationToken cancellationToken) => new User()
            {
                Username = username,
                Password = password,
                IsAdmin = isAdmin,
                CreatedAt = createdAt
            }));
        
        
        // Acts
        var result = await handler.Handle(request, CancellationToken.None);
        
        // Asserts
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Success);
        Assert.IsNotNull(result.Data);
        Assert.AreEqual(username, result.Data.Username);
        Assert.AreEqual(createdAt, result.Data.CreatedAt);
    }
}