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
                    CommandHandler.HandleExit();
                }

                else if (userInput != null && InputValidator.ValidateAddCommand(userInput))
                {

                    CommandHandler.HandleAdd(userInput, tasks);

                    userInput = Console.ReadLine();

                }
                else if (userInput != null && InputValidator.ValidateUpdateCommand(userInput))
                {

                    CommandHandler.HandleUpdate(userInput, tasks);

                    userInput = Console.ReadLine();
                }

                else if (userInput != null && InputValidator.ValidateDeleteCommand(userInput))
                {

                    CommandHandler.HandleDelete(userInput, tasks);
                    userInput = Console.ReadLine();
                }
                //  MARK TASK STATUS
                else if (userInput != null && InputValidator.ValidateDeleteCommand(userInput))
                {

                    userInput = Console.ReadLine();
                }
                else if (userInput != null && InputValidator.ValidateListCommand(userInput))
                {
                    CommandHandler.HandleList(tasks);
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
