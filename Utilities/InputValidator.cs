namespace TaskTrackerSystem.Utilities
{
    public static class InputValidator
    {
        public static bool ValidateAddCommand(string userInput)
        {

            return userInput.Trim().StartsWith("add", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..3] == "add" && userInput.Split(" ")[0] == "add" && userInput.Split(" ").Length > 1;
        }
        public static bool ValidateUpdateCommand(string userInput)
        {
            return userInput.Trim().StartsWith("update", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..6] == "update" && userInput.Split(" ")[0] == "update" && userInput.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries).Length == 3;
        }
        public static bool ValidateDeleteCommand(string userInput)
        {

            return userInput.Trim().StartsWith("delete", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..6] == "delete" && userInput.Split(" ")[0] == "delete" && userInput.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries).Length == 2;
        }
        public static bool ValidateListCommand(string userInput)
        {

            return userInput.Trim().Equals("list", StringComparison.OrdinalIgnoreCase);
        }
        public static bool ValidateMarkStatusCommand(string userInput)
        {
            return userInput.Trim().StartsWith("mark", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..4] == "mark" && userInput.Split("-")[0] == "mark" && userInput.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries).Length == 2;
        }
        public static bool ValidateTaskStatusCommand(string status)
        {
            return status == "done" || status == "in-progress";
        }

        public static bool ValidateListTasksByStatusCommand(string userInput)
        {
            return userInput.Trim().StartsWith("list", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..4] == "list" && userInput.Split(" ")[0] == "list" && userInput.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries).Length == 2;
        }
        public static bool ValidateListTasksByStatus(string status)
        {
            return status == "done" || status == "in-progress" || status == "todo";
        }
    }

}