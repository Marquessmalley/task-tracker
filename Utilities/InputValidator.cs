namespace TaskTrackerSystem.Utilities
{
    public static class InputValidator
    {
        public static bool ValidateAddCommand(string userInput)
        {
            return userInput.Trim().StartsWith("add", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..3] == "add";
        }
        public static bool ValidateUpdateCommand(string userInput)
        {
            return userInput.Trim().StartsWith("update", StringComparison.OrdinalIgnoreCase) && userInput.Trim()[0..6] == "update" && userInput.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries).Length >= 3;
        }
        public static bool ValidateListCommand(string userInput)
        {
            return userInput.Equals("list", StringComparison.OrdinalIgnoreCase);
        }
    }

}