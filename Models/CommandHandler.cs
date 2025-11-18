using System;
using System.Collections;
using TaskTrackerSystem.Utilities;
using TaskTrackerSystem.Model;
using System.Text.Json;

namespace TaskTrackerSystem.Model
{
    public static class CommandHandler
    {

        public static void HandleExit()
        {
            Console.WriteLine("Exiting system...");
            System.Environment.Exit(0);

        }
        public static void HandleAdd(string userInput, Tasks tasks, JsonSerializerOptions JsonOptions)
        {
            // GET THE TODO FROM THE USER INPUT
            string description = userInput.Trim()[3..].Trim();

            // CREATE A NEW TASK
            Todo newTask = new(Guid.NewGuid(), description, TodoStatus.Todo, DateTime.Now, DateTime.Now);

            // ADD IT TO THE TASKS LIST
            tasks.AddTask(newTask);


            // ADD TO A JSON FILE
            var jsonString = JsonSerializer.Serialize(tasks, JsonOptions);

            File.WriteAllText(Path.Combine("Data", "tasks.json"), jsonString);

        }

        public static void HandleUpdate(string userInput, Tasks tasks, JsonSerializerOptions JsonOptions)
        {
            string id = userInput.Split(" ")[1];

            // GET THE TODO FROM THE USER INPUT
            var parts = userInput.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries);
            tasks.UpdateTask(id, parts[2]);

            // UPDATE TO A JSON FILE
            var jsonString = JsonSerializer.Serialize(tasks, JsonOptions);

            File.WriteAllText(Path.Combine("Data", "tasks.json"), jsonString);
        }

        public static void HandleDelete(string userInput, Tasks tasks, JsonSerializerOptions JsonOptions)
        {
            string id = userInput.Split(" ")[1];

            tasks.DeleteTask(id);
            // DELETE TO A JSON FILE
            var jsonString = JsonSerializer.Serialize(tasks, JsonOptions);

            File.WriteAllText(Path.Combine("Data", "tasks.json"), jsonString);

        }
        public static void HandleList(Tasks tasks)
        {
            Console.WriteLine("Listing all tasks...");
            tasks.ListTasks();
        }

        public static void MarkTaskStatus(string userInput, Tasks tasks, JsonSerializerOptions JsonOptions)
        {
            string id = userInput.Split(" ")[1];
            string status = userInput.Split("-", 2, StringSplitOptions.RemoveEmptyEntries)[1].Split(" ")[0];

            if (!InputValidator.ValidateTaskStatusCommand(status))
            {
                Console.WriteLine("Uknown Input. Please try again!");
                return;

            }

            tasks.MarkTaskStatus(id, status);

            // Mark TO A JSON FILE
            var jsonString = JsonSerializer.Serialize(tasks, JsonOptions);

            File.WriteAllText(Path.Combine("Data", "tasks.json"), jsonString);

        }
        public static void ListTasksByStatus(string userInput, Tasks tasks)
        {
            string status = userInput.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)[1];


            if (!InputValidator.ValidateListTasksByStatus(status))
            {
                Console.WriteLine("Uknown Input. Please try again!");
                return;

            }

            tasks.ListTasksByStatus(status);

        }

    }
}