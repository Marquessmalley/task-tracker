using TaskTrackerSystem.Model;
using TaskTrackerSystem.Utilities;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace TaskTrackerSystem
{

    public class TaskTracer
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public static Tasks LoadTasksFromFile(JsonSerializerOptions options)
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

        public static void Main(string[] args)
        {

            Console.WriteLine("Welome to the Task Tracker System!");
            Tasks tasks = LoadTasksFromFile(JsonOptions);


            string? userInput = Console.ReadLine();
            do
            {


                if (userInput?.ToLower() == "exit")
                {
                    CommandHandler.HandleExit();
                }

                else if (userInput != null && InputValidator.ValidateAddCommand(userInput))
                {

                    CommandHandler.HandleAdd(userInput, tasks, JsonOptions);

                    userInput = Console.ReadLine();

                }
                else if (userInput != null && InputValidator.ValidateUpdateCommand(userInput))
                {

                    CommandHandler.HandleUpdate(userInput, tasks, JsonOptions);

                    userInput = Console.ReadLine();
                }

                else if (userInput != null && InputValidator.ValidateDeleteCommand(userInput))
                {

                    CommandHandler.HandleDelete(userInput, tasks, JsonOptions);
                    userInput = Console.ReadLine();
                }
                //  MARK TASK STATUS
                else if (userInput != null && InputValidator.ValidateMarkStatusCommand(userInput))
                {

                    CommandHandler.MarkTaskStatus(userInput, tasks, JsonOptions);
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateListCommand(userInput))
                {
                    CommandHandler.HandleList(tasks);
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateListTasksByStatusCommand(userInput))
                {

                    CommandHandler.ListTasksByStatus(userInput, tasks);
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Uknown Input. Please try again!");
                    userInput = Console.ReadLine();
                }
            } while (userInput != null && !userInput.Equals("exit"));
            Console.WriteLine("Exiting system...");
        }
    }
}
