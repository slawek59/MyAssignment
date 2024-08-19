using MyAssignment.Pages;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using MyAssignment.Driver;
using OpenQA.Selenium;
using DocumentFormat.OpenXml.CustomProperties;
using System.Xml;
using System.Configuration;
using DocumentFormat.OpenXml.Bibliography;
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace MyAssignment.Tests
{
	[TestClass]
	public class UnitTest1
	{
		//IWebDriver driver;

		//LoginPage loginPage;
		//MainPage mainPage;

		//     [TestInitialize]
		//     public void Setup()
		//     {
		//         // TODO tu jest ten chrome driver! a potrzebne rozmaite drivery!
		//         //driver = new ChromeDriver();
		//         //driver.Manage().Window.Maximize();
		//         //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

		//         //var a = Environment.GetCommandLineArgs();
		//         var browser = Environment.GetEnvironmentVariable("Browser");
		////var browser = ConfigurationManager.AppSettings["Browser"];

		//driver = DriverInstance.GetInstance(browser);

		//         //driver.Url = "https://www.saucedemo.com/";
		//     }

		//[TestCleanup]
		//public void Cleanup()
		//{
		//	DriverInstance.CloseBrowser();
		//}

		// TODO rename methods
		// TODO parametryzacja datarowem ? wtedy browsers z datarow
		[TestMethod]
		[DataRow("")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void TestMethod1(string browser)
		{
			//haslo logowania i environment bêdzie z pliku config badaj¿e
			//to mog³aby byæ metoda login po prostu, ale oni wymagaj¹ czyszczenia inputów
			//nowy page dla strony po zalogowaniu
			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps(driver);

			LoginPage loginPage = steps.LoginWithClearedInputs(driver);

			//LoginPage loginPage = new LoginPage(driver);
			//loginPage.OpenPage();
			//loginPage.GetUsernameAreaElement().SendKeys("any");
			//loginPage.GetPasswordAreaElement().SendKeys("any");
			//loginPage.ClearInput("Username");
			//loginPage.ClearInput("Password");
			//loginPage.GetLoginButton().Click();

			string errorMessage = loginPage.GetLoginErrorMessage();
			driver.Quit();

			//Assert.AreEqual(errorMessage, "Username is required");
			// TODO custom message?
			errorMessage.Should().Be("Epic sadface: Username is required");

		}

		[TestMethod]
		[DataRow("")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void TestMethod2(string browser)
		{
			//haslo logowania i environment bêdzie z pliku config badaj¿e
			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps(driver);

			LoginPage loginPage = steps.LoginWithClearedPassword(driver);
			//LoginPage loginPage = new LoginPage(driver);
			//         loginPage.OpenPage();
			//loginPage.GetUsernameAreaElement().SendKeys("invalid_username");
			//         loginPage.GetPasswordAreaElement().SendKeys("secret_sauce");
			//         loginPage.ClearInput("Password");
			//         loginPage.GetLoginButton().Click();
			string errorMessage = loginPage.GetLoginErrorMessage();

			driver.Quit();
			// TODO test must fail
			//Assert.AreEqual(errorMessage, "Password is required");
			errorMessage.Should().Be("Epic sadface: Password is required");


		}

		[TestMethod]
		[DataRow("")]
		[DataRow("Edge")]
		[DataRow("Firefox")]
		public void TestMethod3(string browser)
		{


			//haslo logowania i environment bêdzie z pliku config badaj¿e
			IWebDriver driver = DriverInstance.GetInstance(browser);

			Steps.Steps steps = new Steps.Steps(driver);
			//LoginPage loginPage = new LoginPage(driver);
			//         loginPage.OpenPage();
			//loginPage.GetUsernameAreaElement().SendKeys("standard_user");
			//         loginPage.GetPasswordAreaElement().SendKeys("secret_sauce");
			//         loginPage.GetLoginButton().Click();

			steps.Login(driver);

			MainPage mainPage = new MainPage(driver);
			string title = mainPage.GetTitleElement();

			driver.Quit();
			//DriverInstance.CloseBrowser();
			//Assert.AreEqual(title, "Swag Labs");
			title.Should().Be("Swag Labs");


		}
	}
}