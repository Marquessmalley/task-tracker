using TaskTrackerSystem.Model;
using TaskTrackerSystem.Utilities;

namespace TaskTrackerSystem
{
    public class TaskTracer
    {


        public static void Main(string[] args)
        {

            Console.WriteLine("Welome to the Task Tracker System!");
            Tasks tasks = new();


            string? userInput = Console.ReadLine();
            do
            {


                if (userInput?.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting system...");
                    System.Environment.Exit(0);
                }

                // ADDING TASK
                else if (userInput != null && InputValidator.ValidateAddCommand(userInput))
                {
                    // GET THE TODO FROM THE USER INPUT
                    string description = userInput.Trim()[3..].Trim();

                    // CREATE A NEW TASK
                    Todo newTask = new(Guid.NewGuid(), description, TodoStatus.Todo, DateTime.Now, DateTime.Now);

                    // ADD IT TO THE TASKS LIST
                    tasks.AddTask(newTask);
                    userInput = Console.ReadLine();
                }
                // UPDATING TASK
                else if (userInput != null && InputValidator.ValidateUpdateCommand(userInput))
                {

                    // ID
                    string id = userInput.Split(" ")[1];

                    // GET THE TODO FROM THE USER INPUT
                    var parts = userInput.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries);

                    tasks.UpdateTask(id, parts[2]);

                    // START HERE
                    userInput = Console.ReadLine();
                }
                // DELETING TASK
                else if (userInput != null && InputValidator.ValidateDeleteCommand(userInput))
                {

                    string id = userInput.Split(" ")[1];

                    tasks.DeleteTask(id);

                    // START HERE
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateListCommand(userInput))
                {
                    Console.WriteLine("Listing all tasks...");
                    tasks.ListTasks();
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
