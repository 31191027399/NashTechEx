using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using DemoQASpecFlow.Pages;
using DemoQASpecFlow.Library;
using DemoQASpecFlow.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoQASpecFlow.Steps
{
    [Binding]
    public class DeleteBookFromCollectionSteps
    {
        private string _bookIsbn;
        private string _bookTitle;
        private BookStorePage _bookStorePage = new BookStorePage();
        private LoginPage _loginPage = new LoginPage();
        private ProfilePage _profilePage = new ProfilePage();


        [Given(@"there is a book named ""(.*)"" with ""(.*)""")]
        public void Giventhereisabooknamedwith(string bookTitle, string bookIsbn)
        {
            _bookIsbn = bookIsbn;
        }

        [Given(@"the user logs into the application with ""(.*)"" and ""(.*)""")]
        public void Giventheuserlogsintotheapplicationwithand(string userName, string password)
        {
            APIHelpers.ClearAllBookInCollectionByAPI(userName, password);
            APIHelpers.PostBookToCollectionByAPI(userName, password, _bookIsbn);
            _loginPage.Login(userName,password);
        }

        [Given(@"the user is on the Profile page")]
        public void GiventheuserisontheProfilepage()
        {
        
        }

        [When(@"the user search book ""(.*)""")]
        public void Whentheusersearchbook(string bookTitle)
        {
            _profilePage.EnterSearchKey(bookTitle);
            _bookTitle=bookTitle;
        }

        [When(@"the user clicks on Delete icon")]
        public void WhentheuserclicksonDeleteicon()
        {
            _profilePage.ClickOnDeleteButton(_bookTitle);
        }

        [When(@"the user clicks on OK button")]
        public void WhentheuserclicksonOKbutton()
        {
            _profilePage.ClickOnOkButton();
        }

        [When(@"the user clicks on OK button of alert ""(.*)""")]
        public void WhentheuserclicksonOKbuttonofalert(string alertMessage)
        {
            string realAlert =DriverUtils.ResolveAlert();
            Assert.That(realAlert, Is.EqualTo(alertMessage));
        }

        [Then(@"the book is not shown")]
        public void Thenthebookisnotshown()
        {
           Assert.That(_profilePage.CheckIfBookIsPresentInProfile(_bookTitle), Is.False); 
        }

    }
}

