namespace DocManager.Core.Domain.ValueObjects;

public class FileDefinition
{
    public string FileId { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public string Extension { get; set; } = default!;
    public long Size { get; set; } = default!;
    public Stream? Stream { get; set; }
}