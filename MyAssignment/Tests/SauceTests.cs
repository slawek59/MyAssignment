using FluentAssertions;
using MyAssignment.Driver;
using MyAssignment.Pages;
using OpenQA.Selenium;
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace MyAssignment.Tests
{
	[TestClass]
	public class SauceTests
	{
		[TestMethod]
		[DataRow("")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_BothInputsCleared_ThrowsUsernameErrorMessage(string browser)
		{
			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			LoginPage loginPage = steps.LoginWithClearedInputs(driver);
			string errorMessage = loginPage.GetLoginErrorMessage();

			driver.Quit();

			errorMessage.Should().Be("Username is required");
		}

		[TestMethod]
		[DataRow("")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_PasswordInputCleared_ThrowsPasswordErrorMessage(string browser)
		{
			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			LoginPage loginPage = steps.LoginWithClearedPassword(driver);
			string errorMessage = loginPage.GetLoginErrorMessage();

			driver.Quit();

			errorMessage.Should().Be("Password is required");
		}

		[TestMethod]
		[DataRow("")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_ValidUsernameAndPassword_LogsTotheWebsite(string browser)
		{
			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			steps.Login(driver);

			MainPage mainPage = new MainPage(driver);
			string title = mainPage.GetTitleElement();

			driver.Quit();

			title.Should().Be("Swag Labs");
		}
	}
}