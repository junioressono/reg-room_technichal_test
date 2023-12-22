using DocManager.Core.Business.Users.AddUser;
using DocManager.Core.Business.Users.DeleteUser;
using DocManager.Core.Domain.Entities;
using DocManager.Core.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocManager.Core.UnitTests.DeleteUser;

[TestClass]
public class DeleteUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepoMock;

    public DeleteUserCommandHandlerTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
    }

    [TestMethod]
    public async Task Handle_RequestIdNull_ThrowsException()
    {
        // Arrange
        var request = new DeleteUserRequest(Guid.Empty);
        var handler = new DeleteUserCommandHandler(_userRepoMock.Object);
        
        // Acts & Asserts
        await Assert.ThrowsExceptionAsync<ArgumentNullException>((() => handler.Handle(request, CancellationToken.None)));
    }

    [TestMethod]
    public async Task Handle_RequestIdDefined_DeletedUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new DeleteUserRequest(userId);
        var handler = new DeleteUserCommandHandler(_userRepoMock.Object);
        _userRepoMock.Setup((repository =>
                repository.DeleteUserAsync(It.IsAny<Guid>(), CancellationToken.None)))
            .Verifiable();
        
        
        // Acts
        var result = await handler.Handle(request, CancellationToken.None);
        
        // Asserts
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Success);
        _userRepoMock.VerifyAll();
    }
}