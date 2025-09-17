namespace ToDoList.Models
{
    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
    public class Item
    {

        public int Id { get; set; }
        public required string Text { get; set; }

        public bool IsCompleted { get; set; }

        public PriorityLevel Priority { get; set; }
    }
}
