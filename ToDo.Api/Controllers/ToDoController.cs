using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Services;
using ToDo.Contracts;
using ToDo.DataLayer.Repository;

namespace ToDo.Api
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private IToDoService _service { get; set; }

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        // GET api/todo
        [HttpGet]
        public async Task<ActionResult<IList<ToDoContract>>> Get()
        {

            var response = await _service.GetAll();

            return Ok(response
                .Select(i => new ToDoContract
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    Completed = i.Completed
                })
                .ToList());
        }

        // Post api/todo
        [HttpPost]
        public async Task<ActionResult<ToDoContract>> AddOne([FromBody] ToDoContract todo)
        {

            var response = await _service.AddOne(
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