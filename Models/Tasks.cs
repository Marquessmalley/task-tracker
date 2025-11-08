namespace TaskTrackerSystem.Model
{
    public class Tasks()
    {
        public List<Todo> tasks = [];

        public void ListTasks()
        {

            if (tasks.Count == 0)
            {
                Console.WriteLine("Empty tasks list.");
                return;
            }

            IEnumerable<Todo> list = tasks;

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }

        public void AddTask(Todo task)
        {
            tasks.Add(task);
        }

    }
}