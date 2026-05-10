using System;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.Weshare.Swagger.Client;

namespace Applications.Weshare.Steps
{
    public class CommonSteps
    {
        public static ApiException LastApiException { get; set; }


        [BeforeScenario]
        public void BeforeScenario()
        {
            LastApiException = null;
            StepsHelper.CapturedUsers.Clear();
            StepsHelper.CurrentLoggedInUser = null;
            StepsHelper.CurrentLoggedInPersonId = 0;
            StepsHelper.PaymentRequestsByToPersonId.Clear();
        }

        [Step("Verify status code <Http>")]
        public void VerifyStatusCode(string Http)
        {
            LastApiException.Should().NotBeNull("an API error was expected but none was captured");

            int expectedStatusCode;
            bool parsed = int.TryParse(Http, out expectedStatusCode);

            parsed.Should().BeTrue("Status code must be a numeric value");

            LastApiException.ErrorCode.Should().Be(expectedStatusCode);
        }

        [Step("Verify error message <Message>")]
        public void VerifyErrorMessage(string Message)
        {
            LastApiException.Should().NotBeNull("an API error was expected but none was captured");

            var actualMessage =
                LastApiException.ErrorContent?.ToString()
                ?? LastApiException.Message
                ?? LastApiException.ToString()
                ?? string.Empty;

            actualMessage
                .IndexOf(Message, StringComparison.OrdinalIgnoreCase)
                .Should().BeGreaterThan(
                    -1,
                    $"Expected error message to contain \"{Message}\" but got \"{actualMessage}\""
                );
        }
    }
}