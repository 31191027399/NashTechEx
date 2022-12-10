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
    public class SearchBookSteps
    {
        private BookStorePage _bookStorePage = new BookStorePage();

        [Given(@"there are books named ""(.*)""")]
        public void Giventherearebooksnamed(string bookTitles)
        {
            string checkIfAllSearchedBooksAreInCollection = "";
            AllBooksInfoObject allBooks = APIHelpers.GetAllBookInBookPageByAPI();
            string[] titles = bookTitles.Split(", ");
            foreach (var title in titles)
            {
                bool equal = false;
                for (int i = 0; i < allBooks.Books.Count(); i++)
                {
                    if (allBooks.Books[i].Title == title)
                    {
                        equal = true;
                    }
                }
                checkIfAllSearchedBooksAreInCollection += Convert.ToString(equal);
            }
            Assert.That(checkIfAllSearchedBooksAreInCollection, Does.Not.Contain("false"));
        }


        [Given(@"the user is on the Book Store page")]
        public void GiventheuserisontheBookStorepage()
        {
            _bookStorePage.VisitBookStorePage();
            DriverUtils.HideAds();
        }

        [When(@"the user inputs book name ""(.*)""")]
        public void Whentheuserinputsbookname(string searchText)
        {
            _bookStorePage.EnterKeyWord(searchText);
        }

        [Then(@"all books match with ""(.*)""  will be displayed")]
        public void Thenallbooksmatchwithwillbedisplayed(string searchText)
        {
            List<BookSearchObject> realBooks = _bookStorePage.GetEveryBookInTable();
            foreach (var book in realBooks)
            {
                Assert.That(book.Title.ToLower(), Does.Contain(searchText.ToLower()));
            }
        }
    }
}

