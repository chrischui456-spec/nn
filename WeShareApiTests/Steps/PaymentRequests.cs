using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.Weshare.Swagger.Api;
using Applications.Weshare.Swagger.Model;
using System;
using System.Net.Http;
using static Applications.Weshare.Swagger.Model.PaymentRequestDTO;
using Applications.Weshare.Swagger.Client;

namespace Applications.Weshare.Steps
{
    public class PaymentRequests
    {
        private object result;
        private PaymentRequestDTO paymentRequestDTO;
        private List<PaymentRequestDTO> listPaymentRequestDTO;
        private readonly PaymentRequestsApi _payment = new PaymentRequestsApi(StepsHelper.BasePath);


        [Step("Create request for expenseId <expenseId> fromPersonId <fromPersonId> toPersonId <toPersonId> amount <amount> to be paid by <date>")]
        public void CreateRequestForExpenseidFrompersonidTopersonidAmountToBePaidBy(int expenseId ,int fromPersonId ,int toPersonId ,int amount ,string date)
        {
            NewPaymentRequestDTO newPaymentRequestDTO = new NewPaymentRequestDTO(
                amount : amount,
                expenseId : expenseId,
                fromPersonId : fromPersonId,
                toPersonId :toPersonId,
                date : date
            );

            paymentRequestDTO = _payment.CreatePaymentRequest(newPaymentRequestDTO);
            StepsHelper.LastCreatedPaymentRequestId = paymentRequestDTO.Id;
            
        }

        [Step("Create request for last created expense fromPersonId <fromPersonId> toPersonId <toPersonId> amount <amount> to be paid by <date>")]
        public void CreateRequestForLastCreatedExpense(int fromPersonId ,int toPersonId ,int amount ,string date)
        {
            var expenseId = StepsHelper.LastCreatedExpenseId;
            NewPaymentRequestDTO newPaymentRequestDTO = new NewPaymentRequestDTO(
                amount : amount,
                expenseId : expenseId,
                fromPersonId : fromPersonId,
                toPersonId : toPersonId,
                date : date
            );

            paymentRequestDTO = _payment.CreatePaymentRequest(newPaymentRequestDTO);
            StepsHelper.LastCreatedPaymentRequestId = paymentRequestDTO.Id;
        }


        [Step("Post request for expenseId <expenseId> fromPersonId <fromPersonId> toPersonId <toPersonId> amount <amount> to be paid by <date>")]
        public void PostRequestForExpenseidFrompersonidTopersonidAmountToBePaidBy(string expenseId ,int fromPersonId ,int toPersonId ,string amount ,string date)
        
        {
            int actualExpenseId = expenseId == "last" ? StepsHelper.LastCreatedExpenseId : int.Parse(expenseId);
            int actualAmount = int.Parse(amount);
            
            NewPaymentRequestDTO newPaymentRequestDTO = new NewPaymentRequestDTO(
                amount : actualAmount,
                expenseId : actualExpenseId,
                fromPersonId : fromPersonId,
                toPersonId :toPersonId,
                date : date
            );

            try
            {
                paymentRequestDTO = _payment.CreatePaymentRequest(newPaymentRequestDTO);
                StepsHelper.LastCreatedPaymentRequestId = paymentRequestDTO.Id;
                CommonSteps.LastApiException = null;
            }
            catch (ApiException ex)
            {
                CommonSteps.LastApiException = ex;
            }
        
        }



        [Step("Check that the request was created")]
        public void CheckThatTheRequestWasCreated()
        {
            
            paymentRequestDTO.Should().NotBeNull();
            paymentRequestDTO.Id.Should().BeGreaterThan(0);
        }
     

        [Step("Get all payment requests")]
        public void GetAllPaymentRequests()
        {
            listPaymentRequestDTO = _payment.FindAllPaymentRequests() ?? new List<PaymentRequestDTO>();
        }

        [Step("Check the payment request list is not empty")]
        public void _CheckThePaymentRequestListInNot()
        { 
           listPaymentRequestDTO.Should().NotBeNull();
           listPaymentRequestDTO.Should().NotBeEmpty();
        }


        [Step("Get payments request received by person with Id <Id>")]
        public void GetPaymentsRequestReceivedByPersonWithId(int Id)
        {
            listPaymentRequestDTO = _payment.FindPaymentRequestsReceived(Id) ?? new List<PaymentRequestDTO>();
        }

        [Step("Retrieve payments request received by person with Id <Id>")]
        public void RetrievePaymentsRequestReceivedByPersonWithId(int Id)
        {
            Action action = () =>  _payment.FindPaymentRequestsReceived(Id);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }


        [Step("Verify that the list is empty")]
        public void VerifyThatTheListIsEmpty()
        {
            listPaymentRequestDTO.Should().BeEmpty();
        }


        [Step("Get payments request sent by person with Id <Id>")]
        public void GetPaymentsRequestSentByPersonWithId(int Id)
        {
            listPaymentRequestDTO = _payment.FindPaymentRequestsSent(Id) ?? new List<PaymentRequestDTO>();
        }

        [Step("Retrieve payments request sent by person with Id <Id>")]
        public void RetrievePaymentsRequestSentByPersonWithId(int Id)
        {
            Action action = () =>  _payment.FindPaymentRequestsSent(Id);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }

        
        [Step("Get payment request by id <id>")]
        public void GetPaymentRequestById(string id)
        {
            
            int actualId = id.Trim().ToLower() == "last" ? StepsHelper.LastCreatedPaymentRequestId : int.Parse(id);
            paymentRequestDTO = _payment.GetPaymentRequestById(actualId);
        }
        

        
        [Step("Verify payment request details amount <amount> fromPersonId <fromPersonId> toPersonId <toPersonId> expenseId <expenseId>")]
        public void VerifyPaymentRequestDetails(int amount, int fromPersonId, int toPersonId, string expenseId)
        {
            int actualExpenseId = expenseId.Trim().ToLower() == "last" ? StepsHelper.LastCreatedExpenseId : int.Parse(expenseId);
            paymentRequestDTO.Should().NotBeNull();
            paymentRequestDTO.Amount.Should().Be(amount);
            paymentRequestDTO.FromPersonId.Should().Be(fromPersonId);
            paymentRequestDTO.ToPersonId.Should().Be(toPersonId);
            paymentRequestDTO.ExpenseId.Should().Be(actualExpenseId);
        }
        

        
        [Step("Recall unpaid payment request <id>")]
        public void RecallUnpaidPaymentRequest(int id)
        {
            _payment.RecallUnpaidPaymentRequest(id);
        }
        

        [Step("Verify payment request is paid")]
        public void VerifyPaymentRequestIsPaid()
        {
            var id = StepsHelper.LastCreatedPaymentRequestId;
            paymentRequestDTO = _payment.GetPaymentRequestById(id);
            paymentRequestDTO.Paid.Should().BeTrue();
        }

    }
}