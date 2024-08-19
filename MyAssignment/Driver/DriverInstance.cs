﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MyAssignment.Driver
{
	public class DriverInstance
	{
		public static IWebDriver GetInstance(string browser = "")
		{
			IWebDriver driver;
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
					driver = new ChromeDriver();
					driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
					driver.Manage().Window.Maximize();
					break;
			}
			return driver;
		}
	}
}