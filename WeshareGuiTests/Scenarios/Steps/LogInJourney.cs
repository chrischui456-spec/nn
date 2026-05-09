using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class LogInJourney
    {
        private readonly LogInPage _loginPage = new LogInPage();
        private readonly RequestPage requestPage = new RequestPage();
        private ResultsPage resultsPage;


        [Step("Navigate to login page")]
        public void OpenHomePage() => requestPage.Open();
    

       [Step("Login as <email>")]
        public void LoginAsUser(string email)
        {
            resultsPage = _loginPage.LogIn(email);
        }

        [Step("Click on Payment Request")]
        public void OpenPaymentRequestsSent()
        {
            resultsPage = requestPage.OpenRequestSents();
        }

        [Step("verify <title> section")]
        public void CheckIfItIsSection(string section)
        {
            resultsPage.IsPeopleWhoOweMe(section);
        }

        [Step("Click on Request received")]
        public void OpenPaymentRequestsReceived()
        {
            resultsPage = requestPage.OpenRequestReceived();
        }

        [Step("verify <title> in request received")]
        public void CheckIfItIsSectionReceived(string section)
        {
            resultsPage.IsPeopleThatYouOwe(section);
        }


    }
}
