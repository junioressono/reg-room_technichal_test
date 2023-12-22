namespace DocManager.Core.Domain.Entities;

public class User
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool IsAdmin { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public Guid Id { get; set; }

    public ICollection<Document>? Documents { get; set; }

}
