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
    public class Expenses
    {
        private object result;
        private ExpenseDTO expenseDTO;
        private List<ExpenseDTO> listExpenseDTO;
        private readonly ExpensesApi _expenses = new ExpensesApi(StepsHelper.BasePath);


        [Step("Create expense for personId <personId> description <description> amount <amount> date <date>")]
        public void CreateExpenseForPersonidDescriptionAmountDate(int personId, string description, int amount, string date)
        {
            NewExpenseDTO newExpenseDTO = new NewExpenseDTO(
                description: description,
                amount: amount,
                date: date,
                personId: personId
            );

            expenseDTO = _expenses.CreateExpense(newExpenseDTO);
            StepsHelper.LastCreatedExpenseId = expenseDTO.ExpenseId;
        }



        [Step("Get all expenses")]
        public void GetAllExpenses()
        {
            listExpenseDTO = _expenses.FindAllExpenses() ?? new List<ExpenseDTO>();
        }



        [Step("Get expense by id <id>")]
        public void GetExpenseById(string id)
        {

            int actualId = id.Trim().ToLower() == "last" ? StepsHelper.LastCreatedExpenseId : int.Parse(id);
            expenseDTO = _expenses.FindExpenseById(actualId);
        }



        [Step("Get expenses by person id <personId>")]
        public void GetExpensesByPersonId(int personId)
        {
            listExpenseDTO = _expenses.FindExpensesByPerson(personId) ?? new List<ExpenseDTO>();
        }



        [Step("Check that the expense was created")]
        public void CheckThatTheExpenseWasCreated()
        {
            expenseDTO.Should().NotBeNull();
        }



        [Step("Check the expense list is not empty")]
        public void CheckTheExpenseListIsNotEmpty()
        {
            listExpenseDTO.Should().NotBeNull();
            listExpenseDTO.Should().NotBeEmpty();
        }



        [Step("Verify that the expense list is empty")]
        public void VerifyThatTheExpenseListIsEmpty()
        {
            listExpenseDTO.Should().BeEmpty();
        }



        [Step("Post expense for personId <personId> description <description> amount <amount> date <date>")]
        public void PostExpenseForPersonidDescriptionAmountDate(int personId, string description, int amount, string date)
        {
            NewExpenseDTO newExpenseDTO = new NewExpenseDTO(
                description: description,
                amount: amount,
                date: date,
                personId: personId
            );

            try
            {
                expenseDTO = _expenses.CreateExpense(newExpenseDTO);
                StepsHelper.LastCreatedExpenseId = expenseDTO.ExpenseId;
                CommonSteps.LastApiException = null;
            }
            catch (ApiException ex)
            {
                CommonSteps.LastApiException = ex;
            }
        }



        [Step("Retrieve expense by id <id>")]
        public void RetrieveExpenseById(string id)
        {
            int actualId = id.Trim().ToLower() == "invalid"
                ? StepsHelper.LastCreatedExpenseId + 9999
                : int.Parse(id);

            try
            {
                expenseDTO = _expenses.FindExpenseById(actualId);
                CommonSteps.LastApiException = null;
            }
            catch (ApiException ex)
            {
                CommonSteps.LastApiException = ex;
            }
        }



        [Step("Retrieve expenses by person id <personId>")]
        public void RetrieveExpensesByPersonId(int personId)
        {
            Action action = () => _expenses.FindExpensesByPerson(personId);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }


        [Step("Verify expense nett amount is <amount>")]
        public void VerifyExpenseNettAmountIs(int amount)
        {
            expenseDTO = _expenses.FindExpenseById(StepsHelper.LastCreatedExpenseId);
            expenseDTO.NettAmount.Should().Be(amount);

        }

        

    }
}