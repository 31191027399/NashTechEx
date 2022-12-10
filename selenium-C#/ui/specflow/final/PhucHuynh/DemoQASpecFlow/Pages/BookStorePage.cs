using System.Linq;
using System;
using System.Text;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using System.Collections.Generic;
using DemoQASpecFlow.Models;

namespace DemoQASpecFlow.Pages
{
    public class BookStorePage
    {
        //Web Element
        private WebObject _btnLogin = new WebObject(By.Id("login"), "Login button");
        private string _bookPath = "//a[text()='{0}']";
        private WebObject _txtsearchBox = new WebObject(By.Id("searchBox"), "Search Textbox");
        private WebObject _btnNext = new WebObject(By.ClassName("-next"), "Next button");
        private WebObject _btnNextDisabled = new WebObject(By.CssSelector(".-next button[disabled]"), "Next button disabled");
        private string _tblRowLocator = "div[role='rowgroup']";
        private string _tblPublisherLocator = "div[role='rowgroup']:nth-child({0}) div[class='rt-td']:last-child";
        private string _tblAuthorLocator = "div[role='rowgroup']:nth-child({0}) div[class='rt-td']:nth-child(3)";
        private string _tblTitleLocator = "div[role='rowgroup']:nth-child({0}) div[class='rt-td']:nth-child(2)";
        private WebObject _lblTotalPages = new WebObject(By.ClassName("-totalPages"), "Total Pages");
        //Page method
        public void VisitBookStorePage()
        {
            DriverUtils.GoToUrl(ConfigurationHelper.GetConfigurationByKey("bookStoreURL"));
        }
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
        public int GetTheMaximumValuesOfEachPage()
        {
            IList<IWebElement> _tblAssetListRow = new List<IWebElement>(Context.GetWebDriver().FindElements(By.CssSelector(_tblRowLocator)));
            return _tblAssetListRow.Count;
        }
        private WebObject _getPuslisher(int row)
        {
            return new WebObject(By.CssSelector(string.Format(_tblPublisherLocator, row)), $"Publisher in {row} row ");
        }
        private WebObject _getAuthor(int row)
        {
            return new WebObject(By.CssSelector(string.Format(_tblAuthorLocator, row)), $"Author in {row} row ");
        }
        private WebObject _getTitle(int row)
        {
            return new WebObject(By.CssSelector(string.Format(_tblTitleLocator, row)), $"Title in {row} row ");
        }

        public List<BookSearchObject> GetEveryBookInTable()
        {

            int count = Int32.Parse(DriverUtils.GetTextFromElement(_lblTotalPages));
            List<BookSearchObject> _tblBookInfo = new List<BookSearchObject>();
            for (int i = 1; i <= count; i++)
            {
                int numberOfBooks = GetTheMaximumValuesOfEachPage();
                if (numberOfBooks > 0)
                {
                    for (int m = 1; m <= numberOfBooks; m++)
                    {
                        if (DriverUtils.GetTextFromElement(_getTitle(m)).Count() > 3)
                        {
                            BookSearchObject eachBook = new BookSearchObject(
                           DriverUtils.GetTextFromElement(_getTitle(m)),
                           DriverUtils.GetTextFromElement(_getAuthor(m)),
                           DriverUtils.GetTextFromElement(_getPuslisher(m)));
                            _tblBookInfo.Add(eachBook);
                        }
                    }
                }
                if (count == 1)
                {
                    break;
                }
                if (DriverUtils.IsElementDisplayed(_btnNextDisabled) == false)
                {
                    DriverUtils.ClickOnElement(_btnNext);
                }
            }
            return _tblBookInfo;
        }
    }
}