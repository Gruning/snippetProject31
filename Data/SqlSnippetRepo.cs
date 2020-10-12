using System.Collections.Generic;
using System.Linq;
using SnippetProject31.Models;

namespace SnippetProject31.Data
{
    public class SqlSnippetRepo : ISnippetRepo
    {
        private readonly SnippetContext _context;

        public SqlSnippetRepo(SnippetContext context)
        {
            _context = context;
        }
        public IEnumerable<Snippet> GetAllSnippets()
        {
            return _context.Snippets.ToList();
        }

        public Snippet GetSnippetById(int id)
        {
            return _context.Snippets.FirstOrDefault(x => x.Id == id);
        }
    }
}