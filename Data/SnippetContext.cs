using Microsoft.EntityFrameworkCore;
using SnippetProject31.Models;

namespace SnippetProject31.Data
{
    public class SnippetContext: DbContext
    {
        public SnippetContext(DbContextOptions<SnippetContext> opt) : base(opt)
        {
        }
        public DbSet<Snippet> Snippets { get; set; } 
    }
}