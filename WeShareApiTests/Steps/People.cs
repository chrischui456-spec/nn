using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.Weshare.Swagger.Api;
using Applications.Weshare.Swagger.Model;
using System;
using Applications.Weshare.Swagger.Client;

namespace Applications.Weshare.Steps
{
    public class People
    {
        private Person person;
        private List<Person> listPerson;
        private ApiException lastException;

        private readonly PeopleApi _people = new PeopleApi(StepsHelper.BasePath);

        [Step("Get all people")]
        public void GetAllPeople()
        {
            listPerson = _people.FindAllPeople();
        }

        [Step("The response is successful")]
        public void TheResponseIsSuccessful()
        {
            listPerson.Should().NotBeNull();
        }

        [Step("The people list is not empty")]
        public void ThePeopleListIsNotEmpty()
        {
            listPerson.Should().NotBeNull();
            listPerson.Should().NotBeEmpty();
        }

        [Step("The people list contains <email>")]
        public void ThePeopleListContains(string email)
        {
            listPerson.Should().Contain(p => p.Email == email);
        }


        [Step("Login with email <email>")]
        public void LoginWithEmail(string email)
        {
            var loginDTO = new LoginDTO(email: email);
            person = _people.Login(loginDTO);
        }

        [Step("The user is logged in successfully")]
        public void TheUserIsLoggedInSuccessfully()
        {
            person.Should().NotBeNull();
            person.Email.Should().NotBeNullOrEmpty();
        }

       
        [Step("Login with empty email")]
        public void LoginWithEmptyEmail()
        {
            var loginDTO = new LoginDTO(email: "");
            Action action = () => _people.Login(loginDTO);

            lastException = action.Should().Throw<ApiException>().Which;
        }

        [Step("Login with invalid email <email>")]
        public void LoginWithInvalidEmail(string email)
        {
            var loginDTO = new LoginDTO(email: email);
            Action action = () => _people.Login(loginDTO);

            lastException = action.Should().Throw<ApiException>().Which;
        }

        [Step("The response is a bad request")]
        public void TheResponseIsABadRequest()
        {
            lastException.Should().NotBeNull();
            lastException.ErrorCode.Should().Be(400);
        }


        [Step("Get person by id <id>")]
        public void GetPersonById(int id)
        {
            person = _people.FindPersonById(id);
        }

        [Step("Retrieve person by id <id>")]
        public void RetrievePersonById(int id)
        {
            Action action = () => _people.FindPersonById(id);
            lastException = action.Should().Throw<ApiException>().Which;
        }
    }
}