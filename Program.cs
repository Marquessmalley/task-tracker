using TaskTrackerSystem.Model;

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


                if (userInput == "exit")
                {
                    Console.WriteLine("Exiting system...");
                    System.Environment.Exit(0);
                }
                else if (userInput != null && userInput.StartsWith("add", StringComparison.OrdinalIgnoreCase))
                {
                    // GET THE TODO FROM THE USER INPUT
                    string description = userInput.Split("add")[1];

                    // CREATE A NEW TASK
                    Todo newTask = new(Guid.NewGuid(), description, TodoStatus.Todo, DateTime.Now, DateTime.Now);
                    Console.WriteLine(newTask.ToString());

                    // ADD IT TO THE TASKS LIST
                    tasks.AddTask(newTask);
                    userInput = Console.ReadLine();
                }
                else if (userInput != null && userInput.Equals("list", StringComparison.OrdinalIgnoreCase))
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