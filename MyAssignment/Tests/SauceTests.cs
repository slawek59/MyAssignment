using FluentAssertions;
using MyAssignment.Driver;
using MyAssignment.Logger;
using MyAssignment.Pages;
using OpenQA.Selenium;
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace MyAssignment.Tests
{
	[TestClass]
	public class SauceTests
	{
		private static NLog.Logger _logger;
		private string? _browser;

		[TestInitialize]
		public void TestInitialize()
		{
			_logger = NLog.LogManager.GetCurrentClassLogger();
		}

		[TestMethod]
		[DataRow("Chrome")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_BothInputsCleared_ThrowsUsernameErrorMessage(string browser)
		{
			_logger.Info($"{LoggerMessages.AppOpenedLoggerMessage} Browser: {browser}");
			_browser = browser;

			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			LoginPage loginPage = steps.LoginWithClearedInputs(driver);
			string errorMessage = loginPage.GetLoginErrorMessage();

			driver.Quit();

			try
			{
				errorMessage.Should().Be("Username is required");
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				throw;
			}
		}

		[TestMethod]
		[DataRow("Chrome")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_PasswordInputCleared_ThrowsPasswordErrorMessage(string browser)
		{
			_logger.Info($"{LoggerMessages.AppOpenedLoggerMessage} Browser: {browser}");
			_browser = browser;

			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			LoginPage loginPage = steps.LoginWithClearedPassword(driver);
			string errorMessage = loginPage.GetLoginErrorMessage();

			driver.Quit();

			try
			{
				errorMessage.Should().Be("Password is required");
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				throw;
			}
		}

		[TestMethod]
		[DataRow("Chrome")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_ValidUsernameAndPassword_LogsTotheWebsite(string browser)
		{
			_logger.Info($"{LoggerMessages.AppOpenedLoggerMessage} Browser: {browser}");
			_browser = browser;

			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			steps.Login(driver);

			MainPage mainPage = new MainPage(driver);
			string title = mainPage.GetTitleElement();

			driver.Quit();

			try
			{
				title.Should().Be("Swag Labs");
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				throw;
			}
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_logger.Info($"{LoggerMessages.AppClosedLoggerMessage} Browser: {_browser}");
		}
	}
}