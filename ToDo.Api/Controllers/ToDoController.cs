using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Services;
using ToDo.Models;
using ToDo.DataLayer.Entities;

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
        public async Task<ActionResult<IList<ToDoModel>>> Get()
        {

            var response = await _service.GetAll();

            return Ok(response
                .Select(i => MapEntityToContract(i))
                .ToList());
        }

        // Post api/todo
        [HttpPost]
        public async Task<ActionResult<ToDoModel>> AddOne([FromBody] ToDoModel ToDo)
        {

            var response = await _service.AddOne(MapContractToEntity(ToDo));

            return Ok(MapEntityToContract(response));
        }

        // Put api/todo
        [HttpPut]
        public ActionResult<ToDoModel> UpdateOne([FromBody] ToDoModel ToDo)
        {

            var response = _service.UpdateOne(MapContractToEntity(ToDo));

            return MapEntityToContract(response);
        }

        // Delete api/todo
        [HttpDelete]
        public ActionResult Delete([FromQuery] int Id)
        {
            _service.DeleteOne(new ToDoEntity { Id = Id });

            return Ok();
        }

        private ToDoEntity MapContractToEntity(ToDoModel contract)
        {
            return new ToDoEntity
            {
                Id = contract.Id,
                Title = contract.Title,
                Description = contract.Description,
                Completed = contract.Completed
            };
        }

        private ToDoModel MapEntityToContract(ToDoEntity entity)
        {
            return new ToDoModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Completed = entity.Completed
            };
        }
    }
}