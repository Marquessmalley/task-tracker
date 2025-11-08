using System;

namespace TaskTrakcerSystem.Model

{
    public enum TaskStatus
    {

        Todo,
        InProgress,
        Done
    }


    public class Task
    {
        public int id;
        public string? description;
        public TaskStatus taskStatus;
        public DateTime createdAt;
        public DateTime updatedAt;


    }
}