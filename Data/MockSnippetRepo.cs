using System.Collections.Generic;
using SnippetProject31.Models;

namespace  SnippetProject31.Data
{
    public class MockSnippetRepo : ISnippetRepo
    {
        
        public IEnumerable<Snippet> GetAllSnippets()
        {
            var snipppetList = new List<Snippet>{
                 new Snippet{Id=1 ,HowTo="list all",Line="ll",Platform="bash"},
                  new Snippet{Id=2 ,HowTo="toggle sidebar",Line="ctrl + b",Platform="vscode"},
            };
            return snipppetList;
        }

        public Snippet GetSnippetById(int id)
        {
            return new Snippet{Id=0 ,HowTo="add gitignore file",Line="dotnet new gititgnore",Platform=".NET Core"};
        }
    }
}