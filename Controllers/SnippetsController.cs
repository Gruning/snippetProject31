using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SnippetProject31.Data;
using SnippetProject31.Models;

namespace SnippetProject31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController:ControllerBase
    {
        private readonly MockSnippetRepo _repository = new MockSnippetRepo();
        //GET api/snippets/
        [HttpGet]
        public ActionResult<IEnumerable<Snippet>>GetAllSnippets(){
            var items = _repository.GetAppSnippets();
            return Ok(items);
        }

        //GET api/snippets/{id}
        [HttpGet("{id}")]
        public ActionResult<Snippet> GetSnippetById(int id){
            var item = _repository.GetSnippetById(id);
            return Ok(item);
        }
    }
}