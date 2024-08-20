namespace MyAssignment.Models
{
	public static class User
	{
		private const string VALID_USERNAME = "standard_user";
		private const string VALID_PASSWORD = "secret_sauce";
		private const string INVALID_USERNAME = "invalid_user";
		private const string INVALID_PASSWORD = "invalid_password";

		public static string ValidUsername { get { return VALID_USERNAME; } }
		public static string ValidPassword { get { return VALID_PASSWORD; } }
		public static string InvalidUsername { get { return INVALID_USERNAME; } }
		public static string InvalidPassword { get { return INVALID_PASSWORD; } }

	}
}
