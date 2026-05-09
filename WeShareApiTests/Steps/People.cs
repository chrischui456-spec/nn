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
    public class People
    {
        private object result;
        private Person person;
        private List<Person> listPerson;
        private readonly PeopleApi _people = new PeopleApi(StepsHelper.BasePath);


        [Step("Login with email <email>")]
        public void LoginWithEmail(string email)
        {
            LoginDTO loginDTO = new LoginDTO(email: email);
            person = _people.Login(loginDTO);
        }



        [Step("Get all people")]
        public void GetAllPeople()
        {
            listPerson = _people.FindAllPeople() ?? new List<Person>();
        }



        [Step("Get person by id <id>")]
        public void GetPersonById(int id)
        {
            person = _people.FindPersonById(id);
        }



        [Step("Check that the person was logged in")]
        public void CheckThatThePersonWasLoggedIn()
        {
            person.Should().NotBeNull();
        }



        [Step("Check the people list is not empty")]
        public void CheckThePeopleListIsNotEmpty()
        {
            listPerson.Should().NotBeNull();
            listPerson.Should().NotBeEmpty();
        }



        [Step("Attempt login with email <email>")]
        public void AttemptLoginWithEmail(string email)
        {
            LoginDTO loginDTO = new LoginDTO(email: email);
            Action action = () => _people.Login(loginDTO);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }



        [Step("Retrieve person by id <id>")]
        public void RetrievePersonById(int id)
        {
            Action action = () => _people.FindPersonById(id);
            CommonSteps.LastApiException = action.Should().Throw<ApiException>().Which;
        }


    }
}