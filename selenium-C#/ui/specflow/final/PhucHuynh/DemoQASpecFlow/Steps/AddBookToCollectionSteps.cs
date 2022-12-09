
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using DemoQASpecFlow.Pages;
using DemoQASpecFlow.Library;
using DemoQASpecFlow.Constants;


namespace DemoQASpecFlow.Steps
{
    [Binding]
    public class AddBookToCollectionSteps
    {
        private LoginPage _loginPage = new LoginPage();
        private NavigationPage _navigationPage = new NavigationPage();
        private BookStorePage _bookStorePage = new BookStorePage();
        private SpecificBookPage _specificBookPage = new SpecificBookPage();
        private ProfilePage _profilePage = new ProfilePage();


        [Given(@"the user logs into application by ""(.*)"" and ""(.*)""")]
        public void Giventheuserlogsintoapplicationbyand(string userName, string password)
        {
            _loginPage.Login(userName, password);
            APIHelpers.ClearAllBookInCollectionByAPI(userName, password);
        }

        [Given(@"the user is on Book Store page")]
        public void GiventheuserisonBookStorepage()
        {
            DriverUtils.HideAds();
            _navigationPage.ClickOnbtnBookStore();
        }

        [When(@"the user selects a book ""(.*)""")]
        public void Whentheuserselectsabook(string bookTitle)
        {

            _bookStorePage.EnterKeyWord(bookTitle);
            _bookStorePage.GoToSpecficBookPage(bookTitle);
        }

        [Then(@"an alert ""(.*)"" is shown")]
        public void Thenanalertisshown(string alertMessage)
        {
            DriverUtils.HideAds();
            DriverUtils.KeyPressEnd();
            _specificBookPage.AddBookToCollection();
            string actualMessage = DriverUtils.ResolveAlert();
            Assert.That(alertMessage, Is.EqualTo(actualMessage));
        }
        [Then(@"""(.*)"" is shown in user profile")]
        public void Thenisshowninuserprofile(string bookTitle)
        {
            _navigationPage.ClickOnbtnProfile();
            _profilePage.EnterSearchKey(bookTitle);
            Assert.That(_profilePage.CheckIfBookIsPresentInProfile(bookTitle), Is.True);
        }









    }
}