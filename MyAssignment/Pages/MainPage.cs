using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;
using Microsoft.Testing.Platform.Extensions.CommandLine;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.Extensions.Configuration.CommandLine;
using AngleSharp.Common;
using CommandLine;

namespace MyAssignment.Pages
{
	public class MainPage
	{
		private readonly IWebDriver driver;

		//private const string BASE_URL = "https://www.saucedemo.com/inventory.html";
		readonly By title = By.XPath("//*[@class='app_logo']");

		public MainPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		//public void OpenPage()
		//{
		//	driver.Navigate().GoToUrl(BASE_URL);
		//}

		public string GetTitleElement()
		{
			return driver.FindElement(title).Text;
		}
	}
}
