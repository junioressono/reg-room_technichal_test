using DocManager.Core.Business.Users.GetUsers;
using DocManager.Core.Domain.Entities;
using DocManager.Core.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocManager.Core.UnitTests.GetUsers;

[TestClass]
public class GetUsersQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepoMock;

    public GetUsersQueryHandlerTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
    }

    [TestMethod]
    public async Task Handle_Request_GetUsers()
    {
        // Arrange
        var request = new GetUsersRequest();
        var handler = new GetUsersQueryHandler(_userRepoMock.Object);
        _userRepoMock.Setup((repository =>
                repository.GetUsersAsync(CancellationToken.None)))
            .ReturnsAsync(((CancellationToken cancellationToken) => new List<User>()
            {
                new ()
                {
                    Username = "username1",
                    IsAdmin = true,
                    CreatedAt = DateTime.Now
                }
            }));
        
        
        // Acts
        var result = await handler.Handle(request, CancellationToken.None);
        
        // Asserts
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Success);
        Assert.IsNotNull(result.Data);
        Assert.AreEqual(1, result.Data.Count);
        Assert.AreEqual("username1", result.Data[0].Username);
    }
}