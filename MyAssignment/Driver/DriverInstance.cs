using DocumentFormat.OpenXml.CustomProperties;
using DocumentFormat.OpenXml.ExtendedProperties;
using FluentAssertions.Equivalency;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Page;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace MyAssignment.Driver
{
	public class DriverInstance
	{
		// TODO set path
		public static string RESOURCES_PATH = "MyAssignment\\App.config";
		//private static IWebDriver driver;

		private DriverInstance() { }

		// TODO żeby dawało różne drivery
		// TODO static to ma być?
		public static IWebDriver GetInstance(string browser = "")
		{
			IWebDriver driver;
			//if (driver == null)
			//{
				switch (browser)
				{
					case "Edge":
						driver = new EdgeDriver();
						driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
						driver.Manage().Window.Maximize();
						break;

					case "Firefox":
						driver = new FirefoxDriver();
						driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
						driver.Manage().Window.Maximize();
						break;

					default:
						//new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
						driver = new ChromeDriver();
						driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
						driver.Manage().Window.Maximize();
						break;
				}

			//}
			return driver;
		}

		// TODO to wywalić?
		//public static void CloseBrowser()
		//{
		//	driver.Quit();
		//	driver = null;
		//}
	}
}