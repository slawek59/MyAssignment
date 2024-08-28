namespace MyAssignment.Models
{
	public class ExpectedValues
	{
		private const string _expectedUsernameMissingMessage = "Username is required";
		private const string _expectedPasswordMissingMessage = "Password is required";
		private const string _expectedTitle = "Swag Labs";

		public static string ExpectedUsernameMissingMessage { get => _expectedUsernameMissingMessage; }
		public static string ExpectedPasswordMissingMessage { get => _expectedPasswordMissingMessage; }
		public static string ExpectedTitle { get => _expectedTitle; }
	}
}
