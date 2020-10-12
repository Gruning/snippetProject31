using System.Collections.Generic;
using SnippetProject31.Models;

namespace SnippetProject31.Data
{
    public interface ISnippetRepo{
        bool SaveChanges();
        IEnumerable<Snippet> GetAllSnippets();
        Snippet GetSnippetById(int id);
        void CreateSnippet(Snippet obj);
    }
}