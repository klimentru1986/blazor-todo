using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.DataLayer;
using ToDo.DataLayer.Entities;

namespace ToDo.Api.Services
{
    public class ToDoService : IToDoService
    {

        private readonly DataContext _context;
        private readonly DbSet<ToDoEntity> _dbSet;

        public ToDoService(DataContext dbContext)
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

            await _context.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<ToDoEntity> UpdateOne(ToDoEntity ToDo)
        {
            var res = _dbSet.Update(ToDo);

            await _context.SaveChangesAsync();

            return ToDo;
        }

        public async Task DeleteOne(ToDoEntity ToDo)
        {
            _dbSet.Remove(ToDo);
            await _context.SaveChangesAsync();
        }
    }
}