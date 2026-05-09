using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class PaymentJourney
    {
        private readonly LogInPage _loginPage = new LogInPage();
        private readonly RequestPage requestPage = new RequestPage();
        private ResultsPage resultsPage;


        [Step("Open login page to check")]
        public void OpenHomePage2() => requestPage.Open();
    

       [Step("Login as user <email> to view payment made")]
        public void LoginAsUser2(string email)
        {
            resultsPage = _loginPage.LogIn(email);
        }

        [Step("Open expense Airtime")]
        public void OpenExpenseAirtime()
        {
            resultsPage = requestPage.OpenExpense();
        }

        [Step("Verify that expense description is <Expense> for payment")]
        public void VerifyThatExpenseDescriptionIs2(string Expense)
        {
            resultsPage.IsCorrectExpenseDescription(Expense);
        }

        // [Step("Open payment request sent page")]
        // public void RequestForAirtimeFromPayBy(string email ,string date ,string amount)
        // {
        //     resultsPage = requestPage.CreateExpenseRequest(email,date,amount);
        // }



        [Step("Open payment request sent page")]
        public void OpenPaymentRequestsSent2()
        {
            resultsPage = requestPage.OpenRequestSents();
        }

        [Step("Check if it is <title> section on payment")]
        public void CheckIfItIsSection2(string section)
        {
            resultsPage.IsPeopleWhoOweMe(section);
        }

    }
}
