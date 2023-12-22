namespace DocManager.Core.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public string OriginalName { get; set; } = default!;
    public long Size { get; set; } = default!;
    public string Extension { get; set; } = default!;

    public Guid DocumentMetadataId { get; set; }
    public DocumentMetadata? DocumentMetadata { get; set; }
}