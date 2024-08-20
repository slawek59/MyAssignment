using MyAssignment.Models;
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
			loginPage.GetUsernameAreaElement().SendKeys(User.InvalidUsername);
			loginPage.GetPasswordAreaElement().SendKeys(User.InvalidPassword);
			loginPage.ClearInput("Username");
			loginPage.ClearInput("Password");
			loginPage.GetLoginButton().Click();
			return loginPage;
		}

		public LoginPage LoginWithClearedPassword(IWebDriver driver)
		{
			LoginPage loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.GetUsernameAreaElement().SendKeys(User.InvalidUsername);
			loginPage.GetPasswordAreaElement().SendKeys(User.ValidPassword);
			loginPage.ClearInput("Password");
			loginPage.GetLoginButton().Click();
			return loginPage;
		}

		public LoginPage Login(IWebDriver driver)
		{
			LoginPage loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.GetUsernameAreaElement().SendKeys(User.ValidUsername);
			loginPage.GetPasswordAreaElement().SendKeys(User.ValidPassword);
			loginPage.GetLoginButton().Click();
			return loginPage;
		}
	}
}
