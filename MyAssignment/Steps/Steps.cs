using MyAssignment.Pages;
using OpenQA.Selenium;

namespace MyAssignment.Steps
{
	public class Steps
	{
		public LoginPage LoginWithClearedInputs(IWebDriver driver)
		{
			LoginPage loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.GetUsernameAreaElement().SendKeys("any");
			loginPage.GetPasswordAreaElement().SendKeys("any");
			loginPage.ClearInput("Username");
			loginPage.ClearInput("Password");
			loginPage.GetLoginButton().Click();
			return loginPage;
		}

		public LoginPage LoginWithClearedPassword(IWebDriver driver)
		{
			LoginPage loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.GetUsernameAreaElement().SendKeys("invalid_username");
			loginPage.GetPasswordAreaElement().SendKeys("secret_sauce");
			loginPage.ClearInput("Password");
			loginPage.GetLoginButton().Click();
			return loginPage;
		}

		public LoginPage Login(IWebDriver driver)
		{
			LoginPage loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.GetUsernameAreaElement().SendKeys("standard_user");
			loginPage.GetPasswordAreaElement().SendKeys("secret_sauce");
			loginPage.GetLoginButton().Click();
			return loginPage;
		}
	}
}
