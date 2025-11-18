namespace TaskTrackerSystem.Model

{
    public enum TodoStatus
    {

        Todo,
        InProgress,
        Done
    }


    public class Todo(Guid id, string description, TodoStatus status, DateTime createdAt, DateTime updatedAt)
    {
        public Guid Id { get; set; } = id;
        public string? Description { get; set; } = description;
        public TodoStatus Status { get; set; } = status;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;



        public override string ToString()
        {
            return $"Id: {Id}, Description: {Description}, Status: {Status}, createdAt: {CreatedAt}";
        }
    }


}