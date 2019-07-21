using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.DataLayer.Models;

namespace ToDo.DataLayer.Repository
{
    public interface IToDoRepository
    {
        Task<IList<ToDoEntity>> GetAll();

        Task<ToDoEntity> AddOne(ToDoEntity ToDo);
    }
    public class ToDoRepository : IToDoRepository
    {
        private DataContext _context { get; set; }

        public ToDoRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        private DbSet<ToDoEntity> _getDbSet()
        {
            return _context.ToDoEntity;
        }

        public async Task<IList<ToDoEntity>> GetAll()
        {
            return await _getDbSet().ToArrayAsync();
        }

        public async Task<ToDoEntity> AddOne(ToDoEntity ToDo)
        {
            var res = await _getDbSet().AddAsync(ToDo);

            _context.SaveChanges();

            return res.Entity;
        }
    }
}