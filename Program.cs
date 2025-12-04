using TaskTrackerSystem.Model;
using TaskTrackerSystem.Utilities;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Runtime.CompilerServices;
using TaskTrackerSystem.Service;

namespace TaskTrackerSystem
{

    public class TaskTracker
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Welome to the Task Tracker System!");
            var taskService = new TaskService();

            string? userInput = Console.ReadLine();
            do
            {


                if (userInput?.ToLower() == "exit")
                {
                    CommandHandler.HandleExit();
                }

                else if (userInput != null && InputValidator.ValidateAddCommand(userInput))
                {

                    CommandHandler.HandleAdd(userInput, taskService);

                    userInput = Console.ReadLine();

                }
                else if (userInput != null && InputValidator.ValidateUpdateCommand(userInput))
                {

                    CommandHandler.HandleUpdate(userInput, taskService);

                    userInput = Console.ReadLine();
                }

                else if (userInput != null && InputValidator.ValidateDeleteCommand(userInput))
                {

                    CommandHandler.HandleDelete(userInput, taskService);
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateMarkStatusCommand(userInput))
                {

                    CommandHandler.MarkTaskStatus(userInput, taskService);
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateListCommand(userInput))
                {
                    CommandHandler.HandleList(taskService);
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateListTasksByStatusCommand(userInput))
                {

                    CommandHandler.ListTasksByStatus(userInput, taskService);
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
