using System;
using Microsoft.EntityFrameworkCore;
using ToDo.DataLayer.Models;

namespace ToDo.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ToDoEntity> ToDoEntity { get; set; }
    }
}
