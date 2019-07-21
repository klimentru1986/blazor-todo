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

        ToDoEntity UpdateOne(ToDoEntity ToDo);

        void DeleteOne(ToDoEntity ToDo);
    }
    public class ToDoRepository : IToDoRepository
    {
        private DataContext _context { get; }
        private DbSet<ToDoEntity> _dbSet { get; set; }

        public ToDoRepository(DataContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.ToDoEntity;
        }

        public async Task<IList<ToDoEntity>> GetAll()
        {
            return await _dbSet.ToArrayAsync();
        }

        public async Task<ToDoEntity> AddOne(ToDoEntity ToDo)
        {
            var res = await _dbSet.AddAsync(ToDo);

            _context.SaveChanges();

            return res.Entity;
        }

        public ToDoEntity UpdateOne(ToDoEntity ToDo)
        {
            var res = _dbSet.Update(ToDo);

            _context.SaveChanges();

            return ToDo;
        }

        public void DeleteOne(ToDoEntity ToDo)
        {
            _dbSet.Remove(ToDo);
            _context.SaveChanges();
        }
    }
}