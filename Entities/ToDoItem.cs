namespace Entities
{
    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public PriorityLevel Priority { get; set; }

        public string UserId { get; set; }

    }
}
