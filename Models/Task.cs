namespace TaskTrackerSystem.Model

{
    public enum TodoStatus
    {

        Todo,
        InProgress,
        Done
    }


    public class Todo(Guid id, string description, TodoStatus status, DateTime createdAt, DateTime updatedAAt)
    {
        public Guid Id = id;
        public string? Description = description;
        public TodoStatus Status = status;
        public DateTime CreatedAt = createdAt;
        public DateTime UpdatedAt = updatedAAt;

        public override string ToString()
        {
            return $"Id: {Id}, Description: {Description}, Status: {Status}, createdAt: {CreatedAt}";
        }
    }


}