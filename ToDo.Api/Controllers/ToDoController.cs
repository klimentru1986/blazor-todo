using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using ToDo.Contracts;

namespace ToDo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        // GET api/todo
        [HttpGet]
        public ActionResult<IEnumerable<ToDoContract>> Get()
        {
            return new ToDoContract[] {
                new ToDoContract {Id = 1, Title = "Api", Completed = false},
                new ToDoContract {Id = 2, Title = "Blazor", Completed = false},
                new ToDoContract {Id = 3, Title = "In Memory DB", Completed = false},
             };
        }
    }

}