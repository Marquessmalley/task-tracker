using TaskTrackerSystem.Model;
using System.Text.Json;

namespace TaskTrackerSystem.Utilities
{
    public static class TaskFileManager
    {
        public static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public static Tasks LoadTasksFromFile()
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
    }
}