using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class AddingExpenseJourney
    {
        private readonly LogInPage _loginPage = new LogInPage();

        private readonly ExpensePage expensePage = new ExpensePage();
        private readonly RequestPage requestPage = new RequestPage();

        private ResultsPage resultsPage;


        [Step("Navigate to login page to capture expense")]
        public void OpenHomePage() => requestPage.Open();
    

       [Step("Login as user <email> to capture an expense")]
        public void LoginAsUser(string email)
        {
            resultsPage = _loginPage.LogIn(email);
        }

        [Step("Click on add expenses")]
        public void OpenPaymentRequestsSent()
        {
            resultsPage = expensePage.OpenAddExpense();
        }

        [Step("Enter expense with description <description> amount <amount> and date <date> was created")]
        public void CheckIfExpensesIsCreated(string description, string amount, string date)
        {
             expensePage.EnterExpense(description, amount, date);
        }

    }
}
