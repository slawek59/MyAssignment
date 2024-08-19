using MyAssignment.Driver;
using MyAssignment.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment.Steps
{
	public class Steps
	{
		IWebDriver driver;

        public Steps(IWebDriver driver)
        {
			this.driver = driver;
		}

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
		//public void CloseBrowser()
		//{
		//	DriverInstance.CloseBrowser();
		//	driver = null;
		//}
	}
}
