namespace Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

    }
}
