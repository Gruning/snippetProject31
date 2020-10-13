using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name="GetSnippetById")]
        public ActionResult<SnippetReadDto> GetSnippetById(int id){
            var item = _repository.GetSnippetById(id);
            if (item!= null) return Ok(_mapper.Map<SnippetReadDto>(item));
            else return NotFound();
        }
        //POST api/snippets/
        [HttpPost]
        public ActionResult<SnippetReadDto> CreateSnippet(SnippetCreateDto createDto){
            var objModel = _mapper.Map<Snippet>(createDto);
            _repository.CreateSnippet(objModel);
            _repository.SaveChanges();
            var dto = _mapper.Map<SnippetReadDto>(objModel);
            return CreatedAtRoute(nameof(GetSnippetById), new {Id = dto.Id}, dto);
        }
        //PUT api/snippets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSnippet(int id, SnippetUpdateDto updateDto){
            var objModel = _repository.GetSnippetById(id);
            if(objModel== null) return NotFound();
            _mapper.Map(updateDto,objModel);
            _repository.UpdateSnippet(objModel);
            _repository.SaveChanges();
            return NoContent();
        }
        //PATCH api/snippets/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateSnippet(int id , JsonPatchDocument<SnippetUpdateDto> patchDoc){
            var objModel = _repository.GetSnippetById(id);
            if(objModel== null) return NotFound();
            var objToPatch = _mapper.Map<SnippetUpdateDto>(objModel);
             patchDoc.ApplyTo(objToPatch, ModelState);
             if(!TryValidateModel(objToPatch) ) return ValidationProblem(ModelState);
             _mapper.Map(objToPatch,objModel);
             _repository.UpdateSnippet(objModel);
             _repository.SaveChanges();
             return NoContent();
        }
    }
}