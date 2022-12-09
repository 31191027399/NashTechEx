using System.Reflection.Metadata;
using System.Diagnostics;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoQASpecFlow.Pages
{
    public class SpecificBookPage
    {
        //Web Element
        private WebObject _bookTitle = new WebObject(By.CssSelector("#title-wrapper div:nth-child(2)"), "Book Title");
        private WebObject _btnProfilePage = new WebObject(By.XPath("//span[text()='Profile']/./parent::li"), "Profile button");
        private WebObject _btnAddToCollection = new WebObject(By.XPath("//button[text()='Add To Your Collection']"), "Add to Collection");
        //Page method
        public string GetBookTitle()
        {
            return DriverUtils.GetTextFromElement(_bookTitle);
        }
        public void AddBookToCollection()
        {
            DriverUtils.WaitForPageLoadCompletely();
            DriverUtils.ClickOnElement(_btnAddToCollection);
        }
    }
}