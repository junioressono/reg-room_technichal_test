using DocManager.Core.Domain.Entities;

namespace DocManager.Core.Business.Users.GetUsers;

public class GetUsersResponseItem
{
    public GetUsersResponseItem(User user)
    {
        Id = user.Id;
        Username = user.Username;
        IsAdmin = user.IsAdmin;
        CreatedAt = user.CreatedAt;
    }
    
    public Guid Id { get; } = default!;
    public string Username { get; }
    public bool IsAdmin { get; }
    public DateTime CreatedAt { get; }
}