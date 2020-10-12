using AutoMapper;
using SnippetProject31.Models;
using SnippetProject31.Dtos;

namespace SnippetProject31.Profiles
{
    public class SnippetsProfile: Profile
    {
        public SnippetsProfile()
        {
            //source -> target
            CreateMap<Snippet,SnippetReadDto>();
            CreateMap<SnippetCreateDto, Snippet>();
        }
    }
}