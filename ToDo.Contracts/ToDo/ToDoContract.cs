namespace ToDo.Contracts
{
    public class ToDoContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}