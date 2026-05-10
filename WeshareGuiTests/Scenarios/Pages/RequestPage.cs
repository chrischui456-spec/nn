using FluentAssertions;
using OpenQA.Selenium;

namespace Scenarios.Pages
{
    public class RequestPage
    {
        private const string Url = "http://localhost:5050";

        IWebDriver Driver => GaugeSupport.Driver;

        private IWebElement ExpenseLink =>
            Driver.FindElement(By.Id("payment_request_2"));

        private IWebElement RequestsSentLink =>
            Driver.FindElement(By.Id("paymentrequests_sent"));

        private IWebElement RequestsReceivedLink =>
            Driver.FindElement(By.Id("paymentrequests_received"));

        private IWebElement AmountField =>
            Driver.FindElement(By.Id("amount"));

        private IWebElement EmailField =>
            Driver.FindElement(By.Id("email"));

        private IWebElement DateField =>
            Driver.FindElement(By.Id("due_date"));

        private IWebElement RequestButton =>
            Driver.FindElement(By.Id("submit"));

        public RequestPage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ResultsPage OpenExpense()
        {
            ExpenseLink.Click();
            return new ResultsPage();
        }

        public ResultsPage OpenRequestSents()
        {
            RequestsSentLink.Click();
            return new ResultsPage();
        }

        public ResultsPage OpenRequestReceived()
        {
            RequestsReceivedLink.Click();
            return new ResultsPage();
        }

        public ResultsPage CreateExpenseRequest(
            string email,
            string date,
            string amount)
        {
            EmailField.SendKeys(email);
            AmountField.SendKeys(amount);
            DateField.SendKeys(date);

            RequestButton.Click();

            return new ResultsPage();
        }
    }
}