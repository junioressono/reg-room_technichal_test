using DocManager.Core.Domain.Entities;

namespace DocManager.Core.Domain.Repositories;

public interface IDocumentRepository
{
    Task<Document> CreateDocumentAsync(string title, string description, string originalName, string extension, long size, CancellationToken cancellationToken = default);
    Task<(int Count, IList<Document> Documents)> GetDocumentsAsync(string? searchTerm = null, int pageNumber = 1,  int pageSize = 10, CancellationToken cancellationToken = default);
}