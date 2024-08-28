namespace MyAssignment.Models
{
	public static class User
	{
		private const string _validUsername = "standard_user";
		private const string _validPassword = "secret_sauce";
		private const string _invalidUsername = "invalid_user";
		private const string _invalidPassword = "invalid_password";

		public static string ValidUsername { get => _validUsername; }
		public static string ValidPassword { get => _validPassword; }
		public static string InvalidUsername { get => _invalidUsername; }
		public static string InvalidPassword { get => _invalidPassword; }
	}
}
