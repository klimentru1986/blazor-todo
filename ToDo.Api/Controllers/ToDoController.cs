using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Services;
using ToDo.Models;
using ToDo.DataLayer.Entities;
using AutoMapper;

namespace ToDo.Api
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoService _service;
        private readonly IMapper _mapper;

        public ToDoController(IToDoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/todo
        [HttpGet]
        public async Task<ActionResult<IList<ToDoModel>>> Get()
        {

            var response = await _service.GetAll();

            return Ok(response
                .Select(i => _mapper.Map<ToDoEntity, ToDoModel>(i))
                .ToList());
        }

        // Post api/todo
        [HttpPost]
        public async Task<ActionResult<ToDoModel>> AddOne([FromBody] ToDoModel ToDo)
        {

            var response = await _service.AddOne(_mapper.Map<ToDoModel, ToDoEntity>(ToDo));

            return Ok(_mapper.Map<ToDoEntity, ToDoModel>(response));
        }

        // Put api/todo
        [HttpPut]
        public ActionResult<ToDoModel> UpdateOne([FromBody] ToDoModel ToDo)
        {

            var response = _service.UpdateOne(_mapper.Map<ToDoModel, ToDoEntity>(ToDo));

            return _mapper.Map<ToDoEntity, ToDoModel>(response);
        }

        // Delete api/todo
        [HttpDelete]
        public ActionResult Delete([FromQuery] int Id)
        {
            _service.DeleteOne(new ToDoEntity { Id = Id });

            return Ok();
        }
    }
}