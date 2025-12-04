using System;
using System.Collections;
using TaskTrackerSystem.Model;
using System.Text.Json;
using TaskTrackerSystem.Service;

namespace TaskTrackerSystem.Utilities
{
    public static class CommandHandler
    {

        public static void HandleExit()
        {
            Console.WriteLine("Exiting system...");
            System.Environment.Exit(0);

        }
        public static void HandleAdd(string userInput, TaskService taskService)
        {
            // GET THE TODO FROM THE USER INPUT
            string description = userInput.Trim()[3..].Trim();

            // CREATE A NEW TASK
            Todo newTask = new(Guid.NewGuid(), description, TodoStatus.Todo, DateTime.Now, DateTime.Now);

            // ADD IT TO THE TASKS LIST
            taskService.AddTask(newTask);


            // ADD TO A JSON FILE
            taskService.SaveTasks();

        }

        public static void HandleUpdate(string userInput, TaskService taskService)
        {
            string id = userInput.Split(" ")[1];

            // GET THE TODO FROM THE USER INPUT
            var parts = userInput.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries);

            // UPDATE TASK
            taskService.UpdateTask(id, parts[2]);

            // UPDATE TO A JSON FILE
            taskService.SaveTasks();
        }

        public static void HandleDelete(string userInput, TaskService taskService)
        {
            string id = userInput.Split(" ")[1];

            taskService.DeleteTask(id);

            // DELETE TO A JSON FILE
            taskService.SaveTasks();

        }
        public static void HandleList(TaskService taskService)
        {
            Console.WriteLine("Listing all tasks...");
            taskService.ListTasks();
        }

        public static void MarkTaskStatus(string userInput, TaskService taskService)
        {
            string id = userInput.Split(" ")[1];
            string status = userInput.Split("-", 2, StringSplitOptions.RemoveEmptyEntries)[1].Split(" ")[0];

            if (!InputValidator.ValidateTaskStatusCommand(status))
            {
                Console.WriteLine("Uknown Input. Please try again!");
                return;

            }

            taskService.MarkTaskStatus(id, status);

            // Mark TO A JSON FILE
            taskService.SaveTasks();

        }
        public static void ListTasksByStatus(string userInput, TaskService taskService)
        {
            string status = userInput.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)[1];


            if (!InputValidator.ValidateListTasksByStatus(status))
            {
                Console.WriteLine("Uknown Input. Please try again!");
                return;

            }

            taskService.ListTasksByStatus(status);

        }

    }
}