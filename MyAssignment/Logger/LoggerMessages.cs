namespace MyAssignment.Logger
{
	public static class LoggerMessages
	{
		private const string _appOpenedLoggerMessage = "App started.";
		private const string _appClosedLoggerMessage = "App closed.";
		private const string _usernameMissingLoggerMessage = "Expected errorMessage to be \"Username is required\" but was: ";
		private const string _passwordMissingLoggerMessage = "Expected errorMessage to be \"Password is required\" but was: ";
		private const string _wrongTitleLoggerMessage = "Expected title to be \"\"Swag Labs\"\" but was: ";

		public static string AppOpenedLoggerMessage { get => _appOpenedLoggerMessage; }
		public static string AppClosedLoggerMessage { get => _appClosedLoggerMessage; }
		public static string UsernameMissingLoggerMessage { get => _usernameMissingLoggerMessage; }
		public static string PasswordMissingLoggerMessage { get => _passwordMissingLoggerMessage; }
		public static string WrongTitleLoggerMessage { get => _wrongTitleLoggerMessage; }
	}
}
