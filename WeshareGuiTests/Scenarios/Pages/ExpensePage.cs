using FluentAssertions;
using OpenQA.Selenium;
using static Scenarios.GaugeSupport;

namespace Scenarios.Pages
{
    public class ExpensePage
    {
        private const string Url = "http://localhost:5050";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;

        private static IWebElement AddExpenseLink => Driver.FindElement(By.Id("add_expense"));
        private static IWebElement DescriptionField => Driver.FindElement(By.Id("description"));
        private static IWebElement AmountField => Driver.FindElement(By.Id("amount"));
        private static IWebElement DateField => Driver.FindElement(By.Id("date"));
        private static IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));

        public ExpensePage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ResultsPage OpenAddExpense()
        {
            AddExpenseLink.Click();
            return new ResultsPage();
        }

        public void EnterExpense(string description, string amount, string date)
        {
            // Description
            var descriptionField = Driver.FindElement(By.Id("description"));
            descriptionField.Clear();
            descriptionField.SendKeys(description);

            // Amount
            var amountField = Driver.FindElement(By.Id("amount"));
            amountField.Clear();
            amountField.SendKeys(amount);

            // Date
            var dateField = Driver.FindElement(By.Id("date"));
            dateField.Clear();
            dateField.SendKeys(date);

            // Submit button (adjust id if needed)
            Driver.FindElement(By.Id("submit")).Click();
        }

        public ResultsPage CreateExpense(string description, string amount, string date)
        {
            DescriptionField.SendKeys(description);
            AmountField.SendKeys(amount);
            DateField.SendKeys(date);
            SubmitButton.Click();

            return new ResultsPage();
        }
    }
}