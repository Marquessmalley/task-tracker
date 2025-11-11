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

        public void AddTask(Todo task)
        {
            tasks.Add(task);
        }

        public void UpdateTask(string taskId, string newDescription)
        {


            Todo? task = tasks.Find((task) => task.Id == Guid.Parse(taskId));
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            task.Description = newDescription;

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

    }
}