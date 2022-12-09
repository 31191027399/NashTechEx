using System.Text;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using System.Collections.Generic;

namespace DemoQASpecFlow.Pages
{
    public class BookStorePage 
    {
        //Web Element
        private WebObject _btnLogin = new WebObject(By.Id("login"), "Login button");
        private string _bookPath = "//a[text()='{0}']";
        private WebObject _txtsearchBox = new WebObject(By.Id("searchBox"), "Search Textbox");
        //Page method
        private WebObject _getLnkBook(string bookTitle)
        {
            return new WebObject(By.XPath(string.Format(_bookPath, bookTitle)), $"{bookTitle}");
        }

        public void GoToSpecficBookPage(string bookTitle)
        {
            DriverUtils.ClickOnElement(_getLnkBook(bookTitle));
        }
        public void EnterKeyWord(string keyword)
        {
            DriverUtils.WaitForPageLoadCompletely();
            DriverUtils.EnterText(_txtsearchBox, keyword);
        }
    }
}