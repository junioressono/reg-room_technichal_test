using DocManager.Core.Domain.ValueObjects;

namespace DocManager.Core.Domain.Services;

public interface IFileService
{
    Task<FileDefinition> GetFileAsync(string fileId, CancellationToken cancellationToken = default);
    Task SaveFileAsync(FileDefinition fileDefinition, CancellationToken cancellationToken = default);
}