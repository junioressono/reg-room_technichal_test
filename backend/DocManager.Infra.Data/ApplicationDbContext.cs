using DocManager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Infra.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentMetadata> Metadata { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
}