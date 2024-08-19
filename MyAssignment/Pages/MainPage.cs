using OpenQA.Selenium;

namespace MyAssignment.Pages
{
	public class MainPage
	{
		private readonly IWebDriver driver;

		private readonly By title = By.XPath("//*[@class='app_logo']");
		public MainPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public string GetTitleElement() => driver.FindElement(title).Text;
	}
}
