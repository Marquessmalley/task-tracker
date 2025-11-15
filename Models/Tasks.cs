namespace TaskTrackerSystem.Model
{
    public class Tasks
    {
        public List<Todo> tasks = [];

        public void ListTasks()
        {

            if (tasks.Count == 0)
            {
                Console.WriteLine("Empty tasks list.");
                return;
            }



            foreach (var item in tasks)
            {
                Console.WriteLine(item);
            }

        }

        public void ListTasksByStatus(string status)
        {

            if (tasks.Count == 0)
            {
                Console.WriteLine("Empty tasks list.");
                return;
            }

            var normalized = status.Trim().Replace("-", "").Replace(" ", "");
            if (!Enum.TryParse(normalized, ignoreCase: true, out TodoStatus result))
            {
                Console.WriteLine("Invalid status. Valid values: todo, in-progress, done");
                return;
            }


            foreach (var task in tasks)
            {
                if (task.Status == result)
                {
                    Console.WriteLine(task);
                }
                else
                {
                    Console.WriteLine($"There are no tasks with the status: {result}");
                }
            }

        }

        public void AddTask(Todo task)
        {
            tasks.Add(task);
        }

        public void UpdateTask(string taskId, string newDescription)
        {

            if (!Guid.TryParse(taskId, out Guid result))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }



            Todo? task = tasks.Find((task) => task.Id == result);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;

        }
        public void DeleteTask(string taskId)
        {


            Todo? task = tasks.Find((task) => task.Id == Guid.Parse(taskId));
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            tasks.Remove(task);


        }
        public void MarkTaskStatus(string taskId, string status)
        {


            Todo? task = tasks.Find((task) => task.Id == Guid.Parse(taskId));
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            if (status == "done")
            {
                task.Status = TodoStatus.Done;
            }
            else if (status == "in-progress")
            {
                task.Status = TodoStatus.InProgress;
            }


        }

    }
}