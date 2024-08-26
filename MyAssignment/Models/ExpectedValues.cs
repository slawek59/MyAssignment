namespace MyAssignment.Models
{
	public class ExpectedValues
	{
		private const string EXPECTED_USERNAME_MISSING_MESSAGE = "Username is required";
		private const string EXPECTED_PASSWORD_MISSING_MESSAGE = "Password is required";
		private const string EXPECTED_TITLE = "Swag Labs";

		public static string ExpectedUsernameMissingMessage { get { return EXPECTED_USERNAME_MISSING_MESSAGE; } }
		public static string ExpectedPasswordMissingMessage { get { return EXPECTED_PASSWORD_MISSING_MESSAGE; } }
		public static string ExpectedTitle { get { return EXPECTED_TITLE; } }
	}
}
