using System;
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

        public void CreateSnippet(Snippet obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));
            _context.Snippets.Add(obj);
        }

        public IEnumerable<Snippet> GetAllSnippets()
        {
            return _context.Snippets.ToList();
        }

        public Snippet GetSnippetById(int id)
        {
            return _context.Snippets.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0 ;
        }

        public void UpdateSnippet(Snippet obj){}
    }
}