using System.Text.Json;
using TaskTrackerSystem.Model;

namespace TaskTrackerSystem.Service
{
    public class TaskService
    {
        private readonly Tasks tasks;
        private readonly JsonSerializerOptions JsonOptions;

        public TaskService()
        {
            JsonOptions = new() { WriteIndented = true };
            tasks = LoadTasksFromFile();
        }

        public Tasks LoadTasksFromFile()
        {
            string folder = "Data";
            string filePath = Path.Combine(folder, "tasks.json");

            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory("Data");
                Console.WriteLine("No saved tasks");
                return new Tasks();
            }
            try
            {
                string jsonString = File.ReadAllText(filePath);

                Tasks? tasks = JsonSerializer.Deserialize<Tasks>(jsonString, JsonOptions);
                if (tasks == null)
                {
                    Console.WriteLine("Loading tasks returned null");
                    return new Tasks();
                }
                Console.WriteLine($"Loaded {tasks.tasks.Count} task(s) from file.");

                return tasks;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error loading tasks: {err.Message}");
                return new Tasks();
            }

        }
        public void SaveTasks()
        {
            var jsonString = JsonSerializer.Serialize(tasks, JsonOptions);
            File.WriteAllText(Path.Combine("Data", "tasks.json"), jsonString);
        }

        public void AddTask(Todo task)
        {
            tasks.tasks.Add(task);
        }


        public void UpdateTask(string taskId, string newDescription)
        {

            if (!Guid.TryParse(taskId, out Guid result))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }



            Todo? task = tasks.tasks.Find((task) => task.Id == result);
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


            Todo? task = tasks.tasks.Find((task) => task.Id == Guid.Parse(taskId));
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            tasks.tasks.Remove(task);


        }


        public void ListTasks()
        {

            if (tasks.tasks.Count == 0)
            {
                Console.WriteLine("Empty tasks list.");
                return;
            }



            foreach (var item in tasks.tasks)
            {
                Console.WriteLine(item);
            }

        }

        public void ListTasksByStatus(string status)
        {

            if (tasks.tasks.Count == 0)
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


            foreach (var task in tasks.tasks)
            {
                if (task.Status == result)
                {
                    Console.WriteLine(task);
                }

            }

        }

        public void MarkTaskStatus(string taskId, string status)
        {


            Todo? task = tasks.tasks.Find((task) => task.Id == Guid.Parse(taskId));
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