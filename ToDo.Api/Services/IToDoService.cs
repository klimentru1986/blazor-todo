using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.DataLayer.Entities;

namespace ToDo.Api.Services
{
    public interface IToDoService
    {
        Task<IList<ToDoEntity>> GetAll();
        Task<ToDoEntity> AddOne(ToDoEntity ToDo);
        Task<ToDoEntity> UpdateOne(ToDoEntity ToDo);
        Task DeleteOne(ToDoEntity ToDo);
    }
}