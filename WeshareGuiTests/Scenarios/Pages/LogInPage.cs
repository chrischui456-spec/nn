using OpenQA.Selenium;

namespace Scenarios.Pages
{
    public class LogInPage
    {
        private const string Url = "http://localhost:5050";

        IWebDriver Driver => GaugeSupport.Driver;

        private IWebElement EmailField =>
            Driver.FindElement(By.Id("email"));

        private IWebElement LogInButton =>
            Driver.FindElement(By.Id("submit"));

        public LogInPage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ResultsPage LogIn(string email)
        {
            EmailField.SendKeys(email);

            LogInButton.Click();

            return new ResultsPage();
        }
    }
}