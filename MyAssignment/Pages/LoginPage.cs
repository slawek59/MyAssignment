using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyAssignment.Pages
{
	public class LoginPage
	{
		private readonly IWebDriver _driver;

		private const string BASE_URL = "https://www.saucedemo.com/";
		private readonly By _usernameInputArea = By.XPath("//*[@id='user-name']");
		private readonly By _passwordInputArea = By.XPath("//*[@id='password']");
		private readonly By _loginButton = By.XPath("//*[@id='login-button']");
		private readonly By _loginErrorMessage = By.XPath("//*[@class='error-message-container error']/h3");
		public void OpenPage() => _driver.Navigate().GoToUrl(BASE_URL);
		public LoginPage(IWebDriver driver)
		{
			_driver = driver;
		}
		public IWebElement GetUsernameAreaElement() => _driver.FindElement(_usernameInputArea);
		public IWebElement GetPasswordAreaElement() => _driver.FindElement(_passwordInputArea);
		public IWebElement GetLoginButton() => _driver.FindElement(_loginButton);
		public string GetLoginErrorMessage() => _driver.FindElement(_loginErrorMessage).Text;

		public void ClearInput(string inputName)
		{
			switch (inputName)
			{
				case "Username":
					Actions usernameAction = new Actions(_driver);
					usernameAction.MoveToElement(GetUsernameAreaElement()).DoubleClick().Click().SendKeys(Keys.Backspace).Perform();
					break;
				case "Password":
					Actions passwordAction = new Actions(_driver);
					passwordAction.MoveToElement(GetPasswordAreaElement()).DoubleClick().Click().SendKeys(Keys.Backspace).Perform();
					break;
			}
		}
	}
}