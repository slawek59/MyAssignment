using FluentAssertions;
using MyAssignment.Driver;
using MyAssignment.Logger;
using MyAssignment.Models;
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
		private IWebDriver _driver;

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

			_driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			LoginPage loginPage = steps.LoginWithClearedInputs(_driver);
			string errorMessage = loginPage.GetLoginErrorMessage();
			string expectedUsernameMessage = ExpectedValues.ExpectedUsernameMissingMessage;

			if (!errorMessage.Equals(expectedUsernameMessage))
			{
				_logger.Error($"{LoggerMessages.UsernameMissingLoggerMessage}{errorMessage}");
			}

			errorMessage.Should().Be(expectedUsernameMessage);
		}

		[TestMethod]
		[DataRow("Chrome")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_PasswordInputCleared_ThrowsPasswordErrorMessage(string browser)
		{
			_logger.Info($"{LoggerMessages.AppOpenedLoggerMessage} Browser: {browser}");
			_browser = browser;

			_driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			LoginPage loginPage = steps.LoginWithClearedPassword(_driver);
			string errorMessage = loginPage.GetLoginErrorMessage();
			string expectedPasswordMessage = ExpectedValues.ExpectedPasswordMissingMessage;

			if (!errorMessage.Equals(expectedPasswordMessage))
			{
				_logger.Error($"{LoggerMessages.PasswordMissingLoggerMessage}{errorMessage}");
			}

			errorMessage.Should().Be(expectedPasswordMessage);
		}

		[TestMethod]
		[DataRow("Chrome")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void LoginToTheWebsite_ValidUsernameAndPassword_LogsTotheWebsite(string browser)
		{
			_logger.Info($"{LoggerMessages.AppOpenedLoggerMessage} Browser: {browser}");
			_browser = browser;

			_driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps();

			steps.Login(_driver);

			MainPage mainPage = new MainPage(_driver);
			string title = mainPage.GetTitleElement();
			string expectedTitle = ExpectedValues.ExpectedTitle;

			if (!title.Equals(expectedTitle))
			{
				_logger.Error($"{LoggerMessages.WrongTitleLoggerMessage}{title}");
			}

			title.Should().Be(expectedTitle);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_driver.Quit();
			_logger.Info($"{LoggerMessages.AppClosedLoggerMessage} Browser: {_browser}");
		}
	}
}