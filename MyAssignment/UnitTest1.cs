using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Runtime.CompilerServices;

namespace MyAssignment
{
	public class LoginPage
	{
		private readonly WebDriver driver;

		readonly By usernameInputArea = By.XPath("//*[@id='user-name']");
		readonly By passwordInputArea = By.XPath("//*[@id='password']");
		readonly By loginButton = By.XPath("//*[@id='login-button']");
		readonly By title = By.XPath("//*[@class='app_logo']");
		readonly By loginErrorMessage = By.XPath("//*[@class='error-message-container error']/h3");

		public LoginPage(WebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement GetUsernameAreaElement()
		{
			return driver.FindElement(usernameInputArea);
		}

		public IWebElement GetPasswordAreaElement()
		{
			return driver.FindElement(passwordInputArea);
		}

		public IWebElement GetLoginButton()
		{
			return driver.FindElement(loginButton);
		}

		public string GetTitleElement()
		{
			return driver.FindElement(title).Text;
		}

		public string GetLoginErrorMessage()
		{
			return driver.FindElement(loginErrorMessage).Text;
		}

		public void ClearInput(string inputName)
		{
			switch (inputName)
			{
				case "Username":
					Actions usernameAction = new Actions(driver);
					usernameAction.MoveToElement(GetUsernameAreaElement()).DoubleClick().Click().SendKeys(Keys.Backspace).Perform();
					break;
				case "Password":
					Actions passwordAction = new Actions(driver);
					passwordAction.MoveToElement(GetPasswordAreaElement()).DoubleClick().Click().SendKeys(Keys.Backspace).Perform();
					break;
			}
		}
	}

	[TestClass]
	public class UnitTest1
	{
		ChromeDriver driver;
		LoginPage page;

		[TestInitialize]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Url = "https://www.saucedemo.com/";
			page = new LoginPage(driver);
		}

		[TestMethod]
		public void TestMethod1()
		{
			//haslo logowania i environment bêdzie z pliku config badaj¿e
			page.GetUsernameAreaElement().SendKeys("any");
			page.GetPasswordAreaElement().SendKeys("any");
			page.ClearInput("Username");
			page.ClearInput("Password");
			page.GetLoginButton().Click();
			string errorMessage = page.GetLoginErrorMessage();

			Assert.AreEqual(errorMessage, "Username is required");

			Thread.Sleep(1000);
		}

		[TestMethod]
		public void TestMethod2()
		{
			//haslo logowania i environment bêdzie z pliku config badaj¿e
			page.GetUsernameAreaElement().SendKeys("any");
			page.GetPasswordAreaElement().SendKeys("secret_sauce");
			page.ClearInput("Password");
			page.GetLoginButton().Click();
			string errorMessage = page.GetLoginErrorMessage();

			Assert.AreEqual(errorMessage, "Password is required");

			Thread.Sleep(1000);
		}

		[TestMethod]
		public void TestMethod3()
		{
			//haslo logowania i environment bêdzie z pliku config badaj¿e
			page.GetUsernameAreaElement().SendKeys("standard_user");
			page.GetPasswordAreaElement().SendKeys("secret_sauce");
			page.GetLoginButton().Click();
			string title = page.GetTitleElement();

			Assert.AreEqual(title, "Swag Labs");

			Thread.Sleep(1000);
		}

		[TestCleanup]
		public void Cleanup()
		{
			driver.Dispose();
		}
	}
}