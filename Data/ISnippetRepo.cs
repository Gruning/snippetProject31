using System.Collections.Generic;
using SnippetProject31.Models;

namespace SnippetProject31.Data
{
    public interface ISnippetRepo{
        IEnumerable<Snippet> GetAppSnippets();
        Snippet GetSnippetById(int id);
    }
}