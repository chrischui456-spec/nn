using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.Weshare.Swagger.Api;
using Applications.Weshare.Swagger.Model;
using System;
using System.Net.Http;
using Applications.Weshare.Swagger.Client;

namespace Applications.Weshare.Steps
{
    public class Payments
    {
        private object result;
        private PaymentDTO paymentDTO;
        private List<PaymentDTO> listPaymentDTO;
        private readonly PaymentsApi _payments = new PaymentsApi(StepsHelper.BasePath);


        [Step("Pay payment request <paymentRequestId> for expense <expenseId> by person <payingPersonId>")]
        public void PayPaymentRequest(int paymentRequestId, int expenseId, int payingPersonId)
        {
            NewPaymentDTO newPaymentDTO = new NewPaymentDTO(
                expenseId: expenseId,
                paymentRequestId: paymentRequestId,
                payingPersonId: payingPersonId
            );
            paymentDTO = _payments.PayPaymentRequest(newPaymentDTO);
        }


        [Step("Pay payment request for last created request amount <amount>")]
        public void PayPaymentRequestForLastCreatedRequestAmount(int amount)
        {
            var paymentRequestId = StepsHelper.LastCreatedPaymentRequestId;
            var expenseId = StepsHelper.LastCreatedExpenseId;
            var payingPersonId = StepsHelper.CurrentLoggedInPersonId > 0 ? StepsHelper.CurrentLoggedInPersonId : 3;
            NewPaymentDTO newPaymentDTO = new NewPaymentDTO(
                expenseId: expenseId,
                paymentRequestId: paymentRequestId,
                payingPersonId: payingPersonId
            );
            paymentDTO = _payments.PayPaymentRequest(newPaymentDTO);
        }

        [Step("Attempt pay payment request for last created request amount <amount>")]
        public void AttemptPayPaymentRequestForLastCreatedRequestAmount(int amount)
        {
            var paymentRequestId = StepsHelper.LastCreatedPaymentRequestId;
            var expenseId = StepsHelper.LastCreatedExpenseId;
            var payingPersonId = StepsHelper.CurrentLoggedInPersonId > 0 ? StepsHelper.CurrentLoggedInPersonId : 3;
            NewPaymentDTO newPaymentDTO = new NewPaymentDTO(
                expenseId: expenseId,
                paymentRequestId: paymentRequestId,
                payingPersonId: payingPersonId
            );
            Action action = () => _payments.PayPaymentRequest(newPaymentDTO);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }


        [Step("Get payments made by person id <personId>")]
        public void GetPaymentsMadeByPersonId(int personId)
        {
            listPaymentDTO = _payments.FindPaymentsMadeByPerson(personId) ?? new List<PaymentDTO>();
        }



        [Step("Check that the payment was created")]
        public void CheckThatThePaymentWasCreated()
        {

            paymentDTO.Should().NotBeNull();
            paymentDTO.Id.Should().BeGreaterThan(0);
        }



        [Step("Verify payment amount is <amount>")]
        public void VerifyPaymentAmountIs(int amount)
        {
            paymentDTO.Amount.Should().Be(amount);
        }

        [Step("Verify payment was created for payment request id <paymentRequestId>")]
        public void VerifyPaymentWasCreatedForPaymentRequestId(int paymentRequestId)
        {
            paymentDTO.PaymentRequestId.Should().Be(paymentRequestId);
        }

        [Step("Verify payment was made for expense id <expenseId>")]
        public void VerifyPaymentWasMadeForExpenseId(string expenseId)
        {
            int actualExpenseId = expenseId.Trim().ToLower() == "last" ? StepsHelper.LastCreatedExpenseId : int.Parse(expenseId);
            paymentDTO.ExpenseId.Should().Be(actualExpenseId);
        }

        [Step("Verify payment created a new expense")]
        public void VerifyPaymentCreatedANewExpense()
        {

            paymentDTO.ExpenseId.Should().NotBe(StepsHelper.LastCreatedExpenseId);
        }



        [Step("Check the payment list is not empty")]
        public void CheckThePaymentListIsNotEmpty()
        {
            listPaymentDTO.Should().NotBeNull();
            listPaymentDTO.Should().NotBeEmpty();
        }



        [Step("Verify that the payment list is empty")]
        public void VerifyThatThePaymentListIsEmpty()
        {
            listPaymentDTO.Should().BeEmpty();
        }



        [Step("Attempt to pay payment request <paymentRequestId> for expense <expenseId> by person <payingPersonId>")]
        public void AttemptToPayPaymentRequest(int paymentRequestId, int expenseId, int payingPersonId)
        {
            NewPaymentDTO newPaymentDTO = new NewPaymentDTO(
                expenseId: expenseId,
                paymentRequestId: paymentRequestId,
                payingPersonId: payingPersonId
            );
            Action action = () => _payments.PayPaymentRequest(newPaymentDTO);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }



        [Step("Retrieve payments made by person id <personId>")]
        public void RetrievePaymentsMadeByPersonId(int personId)
        {
            Action action = () => _payments.FindPaymentsMadeByPerson(personId);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }


        [Step("Verify payment exists for person <personId>")]
        public void VerifyPaymentExistsForPerson(int personId)
        {
            listPaymentDTO = _payments.FindPaymentsMadeByPerson(personId) ?? new List<PaymentDTO>();
            listPaymentDTO.Should().NotBeEmpty("Payment should exist for person " + personId);
        }

    }
}