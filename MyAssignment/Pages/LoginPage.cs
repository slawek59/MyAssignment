using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyAssignment.Pages
{
	public class LoginPage
	{
		private readonly IWebDriver driver;

		private const string BASE_URL = "https://www.saucedemo.com/";
		private readonly By usernameInputArea = By.XPath("//*[@id='user-name']");
		private readonly By passwordInputArea = By.XPath("//*[@id='password']");
		private readonly By loginButton = By.XPath("//*[@id='login-button']");
		private readonly By loginErrorMessage = By.XPath("//*[@class='error-message-container error']/h3");
		public void OpenPage() => driver.Navigate().GoToUrl(BASE_URL);
		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
		}
		public IWebElement GetUsernameAreaElement() => driver.FindElement(usernameInputArea);
		public IWebElement GetPasswordAreaElement() => driver.FindElement(passwordInputArea);
		public IWebElement GetLoginButton() => driver.FindElement(loginButton);
		public string GetLoginErrorMessage() => driver.FindElement(loginErrorMessage).Text;

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
}