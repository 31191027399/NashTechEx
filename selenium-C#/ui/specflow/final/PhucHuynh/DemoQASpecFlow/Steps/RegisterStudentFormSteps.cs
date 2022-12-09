
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using DemoQASpecFlow.Pages;
using DemoQASpecFlow.Library;
using DemoQASpecFlow.Constants;

namespace DemoQASpecFlow.Steps
{
    [Binding]
    public class RegisterStudentFormSteps
    {
        private RegisterStudentFormPage _registerStudentFormPage = new RegisterStudentFormPage();
        private StudentInfoPage _studentInfoPage = new StudentInfoPage();


        [Given(@"User is on Student Registration Form")]
        public void GivenUserisonStudentRegistrationForm()
        {
            _registerStudentFormPage.VisitRegisterStudentForm();
        }


        [When(@"the user input valid data into all fields")]
        public void Whentheuserinputvaliddataintoallfields(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            DriverUtils.HideAds();
            _registerStudentFormPage.InputDataIntoAllFields(dictionary["firstName"], dictionary["lastName"],
            dictionary["email"], dictionary["gender"], dictionary["mobile"], dictionary["dateOfBirth"], dictionary["subjects"], dictionary["hobbies"],
            dictionary["picture"], dictionary["currentAddress"], dictionary["state"], dictionary["city"]);
        }


        [When(@"the user clicks on Submit button")]
        public void WhentheuserclicksonSubmitbutton()
        {
            _registerStudentFormPage.ClickBtnSubmit();
        }

        [Then(@"a successful message is shown")]
        public void Thenasuccessfulmessageisshown()
        {
            Assert.That(_studentInfoPage.GetThankYouLabel(), Is.EqualTo(SystemMessage.RegisterStudentSuccessfullyMessage));
        }

        [Then(@"all information of the student form is shown correctly")]
        public void Thenallinformationofthestudentformisshowncorrectly(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            string name = dictionary["firstName"] + " " + dictionary["lastName"];
            string stateAndCity="";
            if (dictionary["state"] != "" && dictionary["city"] != "")
            {  stateAndCity = dictionary["state"] + " " + dictionary["city"]; }
            else { stateAndCity = dictionary["state"]; }
            Assert.That(_studentInfoPage.GetName(), Is.EqualTo(name));
            Assert.That(_studentInfoPage.GetEmail, Is.EqualTo(dictionary["email"]));
            Assert.That(_studentInfoPage.GetGender, Is.EqualTo(dictionary["gender"]));
            Assert.That(_studentInfoPage.GetMobile(), Is.EqualTo(dictionary["mobile"]));
            if (dictionary["dateOfBirth"] != "")
            { Assert.That(_studentInfoPage.GetBirthday(), Is.EqualTo(dictionary["dateOfBirth"])); }
            else
            { Assert.That(_studentInfoPage.GetBirthday(), Is.EqualTo(DateTime.Today.ToString("dd MMMM,yyyy"))); }
            Assert.That(_studentInfoPage.GetSubjects(), Is.EqualTo(dictionary["subjects"]));
            Assert.That(_studentInfoPage.GetHobbies(), Is.EqualTo(dictionary["hobbies"]));
            Assert.That(_studentInfoPage.GetPicture(), Is.EqualTo(dictionary["picture"]));
            Assert.That(_studentInfoPage.GetAddress(), Is.EqualTo(dictionary["currentAddress"]));
            Assert.That(_studentInfoPage.GetStateandCity(), Is.EqualTo(stateAndCity));
        }
    }
}