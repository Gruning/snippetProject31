using AutoMapper;
using SnippetProject31.Models;
using SnippetProject31.Dtos;

namespace SnippetProject31.Profiles
{
    public class SnippetsProfile: Profile
    {
        public SnippetsProfile()
        {
            CreateMap<Snippet,SnippetReadDto>();
        }
    }
}