using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using ToDo.Contracts;
using ToDo.DataLayer.Repository;

namespace ToDo.Api
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private IToDoRepository _repository { get; set; }

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        // GET api/todo
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var response = await _repository.GetAll();

            return Ok(response);
        }

        // Post api/todo
        [HttpPost]
        public async Task<ActionResult> AddOne([FromBody] ToDoContract todo)
        {

            var response = await _repository.AddOne(
                new DataLayer.Models.ToDoEntity
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    Completed = todo.Completed
                }
            );

            return Ok(new ToDoContract
            {
                Id = response.Id,
                Title = response.Title,
                Description = response.Description,
                Completed = response.Completed
            });
        }
    }

}