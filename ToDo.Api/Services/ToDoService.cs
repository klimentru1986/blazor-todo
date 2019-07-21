using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.DataLayer.Models;
using ToDo.DataLayer.Repository;

namespace ToDo.Api.Services
{
    public interface IToDoService
    {
        Task<IList<ToDoEntity>> GetAll();
        Task<ToDoEntity> AddOne(ToDoEntity ToDo);
    }
    public class ToDoService : IToDoService
    {

        private IToDoRepository _repository { get; set; }
        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ToDoEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ToDoEntity> AddOne(ToDoEntity ToDo)
        {
            return await _repository.AddOne(ToDo);
        }
    }
}