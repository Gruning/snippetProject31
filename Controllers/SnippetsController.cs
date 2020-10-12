using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SnippetProject31.Data;
using SnippetProject31.Dtos;
using SnippetProject31.Models;

namespace SnippetProject31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController:ControllerBase
    {
        private readonly ISnippetRepo _repository;
        private readonly IMapper _mapper;

        public SnippetsController(ISnippetRepo repository, IMapper mapper)
        {  
           _repository = repository; 
           _mapper = mapper;
        }
        //private readonly MockSnippetRepo _repository = new MockSnippetRepo();
        //GET api/snippets/
        [HttpGet]
        public ActionResult<IEnumerable<SnippetReadDto>>GetAllSnippets(){
            var items = _repository.GetAllSnippets();
            return Ok(_mapper.Map<IEnumerable<SnippetReadDto>>(items));
        }

        //GET api/snippets/{id}
        [HttpGet("{id}")]
        public ActionResult<SnippetReadDto> GetSnippetById(int id){
            var item = _repository.GetSnippetById(id);
            if (item!= null) return Ok(_mapper.Map<SnippetReadDto>(item));
            else return NotFound();
        }
    }
}