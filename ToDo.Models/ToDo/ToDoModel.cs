using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}