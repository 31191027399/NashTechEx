using System.Reflection.Metadata;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.Extensions;

namespace DemoQASpecFlow.Pages
{
    public class ProfilePage
    {
        //Web elements
        private WebObject _txtsearchBox = new WebObject(By.Id("searchBox"), "Search Textbox");
        private string _bookPath = "//a[text()='{0}']";
        private string _deletebuttonPath = "//a[text()='{0}']/./ancestor::div[@role='row']/./descendant::span[@title]";
        private WebObject _btnOK = new WebObject(By.XPath("//button[text()='OK']"), "OK confirmation");
        private WebObject _lbltotalPages = new WebObject(By.ClassName("-totalPages"), "Total Page");
        private WebObject _btnNextPage = new WebObject(By.XPath("//button[text()='Next']"), "Next button");
        
        //Page method
        private WebObject _getLnkBook(string bookTitle)
        {
            return new WebObject(By.XPath(string.Format(_bookPath, bookTitle)), $"{bookTitle}");
        }
        private WebObject _getBtnDelete(string bookTitle)
        {
            return new WebObject(By.XPath(string.Format(_deletebuttonPath, bookTitle)), $"{bookTitle}");
        }
        public void EnterSearchKey( string keyword)
        {
            DriverUtils.WaitForPageLoadCompletely();
            DriverUtils.EnterText(_txtsearchBox,keyword);
        }
        public bool CheckIfBookIsPresentInProfile(string bookTitle)
        {
            return DriverUtils.IsElementDisplayed(_getLnkBook(bookTitle));
        }
        public void ClickOnDeleteButton(string bookTitle)
        {
            DriverUtils.ClickOnElement(_getBtnDelete(bookTitle));
        }
        public void ClickOnOkButton()
        {
            DriverUtils.ClickOnElement(_btnOK);
        }
    }
}