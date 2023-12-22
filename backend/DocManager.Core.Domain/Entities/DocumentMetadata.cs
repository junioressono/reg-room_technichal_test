using DocManager.Core.Domain.ValueObjects;

namespace DocManager.Core.Domain.Entities;

public class DocumentMetadata
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DocumentScope Scope { get; set; }
}