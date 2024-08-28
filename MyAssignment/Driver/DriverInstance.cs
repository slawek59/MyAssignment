using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MyAssignment.Driver
{
	public static class DriverInstance
	{
		public static IWebDriver GetInstance(string browser = "")
		{
			IWebDriver driver;
			switch (browser)
			{
				case "Chrome":
					driver = new ChromeDriver();
					break;

				case "Edge":
					driver = new EdgeDriver();
					break;

				case "Firefox":
					driver = new FirefoxDriver();
					break;

				default:
					driver = new ChromeDriver();
					break;
			}

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			driver.Manage().Window.Maximize();
			
			return driver;
		}
	}
}