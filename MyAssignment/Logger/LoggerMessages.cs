namespace MyAssignment.Logger
{
	public static class LoggerMessages
	{
		public static string AppOpenedLoggerMessage { get; } = "App started.";
		public static string AppClosedLoggerMessage { get; } = "App closed.";

		public static string UsernameMissingLoggerMessage { get; } = "Expected errorMessage to be \"Username is required\" but was: ";
		public static string PasswordMissingLoggerMessage { get; } = "Expected errorMessage to be \"Password is required\" but was: ";
		public static string WrongTitleLoggerMessage { get; } = "Expected title to be \"\"Swag Labs\"\" but was: ";
	}
}
