using FluentAssertions;
using OpenQA.Selenium;
using Scenarios;


namespace Scenarios.Pages
{
    public class ResultsPage
    {
        private readonly string _text;

        public ResultsPage(string text)
        {
            _text = text;
        }

         public ResultsPage()
        {
        }

        public ResultsPage IsCorrectExpenseDescription(string expense)
        {
            GaugeSupport.Driver.FindElement(By.Id("expense_description")).Text.Should().Be(expense);
            return this;
        }

        public ResultsPage RequestSentToStudent(string name, string amount, string IsPaid)
        {
            GaugeSupport.Driver.FindElement(By.Id("paymentrequest_who_3")).Text.Should().Be(name);
            GaugeSupport.Driver.FindElement(By.Id("paymentrequest_paid_3")).Text.Should().Be(IsPaid);
            GaugeSupport.Driver.FindElement(By.Id("paymentrequest_amount_3")).Text.Should().Be(amount);
            return this;
        }

        public ResultsPage ExpenseCreated(string description, string amount, string date)
        {
            GaugeSupport.Driver.FindElement(By.Id("description")).Text.Should().Be(description);
            GaugeSupport.Driver.FindElement(By.Id("amount")).Text.Should().Be(amount);
            GaugeSupport.Driver.FindElement(By.Id("date")).Text.Should().Be(date);

            return this;
        }

        public ResultsPage IsPeopleWhoOweMe(string title)
        {
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/h2")).Text.Should().Be(title);
            return this;
        }

        public ResultsPage IsPeopleThatYouOwe(string title)
        {
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/h2")).Text.Should().Be(title);
            return this;
        }

         public ResultsPage IsAddedToPaymentRequestSent(string name, string amount, string expense)
        {
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/table/tbody/tr[3]/td[1]")).Text.Should().Be(expense);
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/table/tbody/tr[3]/td[2]")).Text.Should().Be(name);
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/table/tbody/tr[3]/td[4]")).Text.Should().Be(amount);
            return this;
        }

    }
}