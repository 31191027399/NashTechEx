using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQASpecFlow.Models
{
    public class BookSearchObject
    {
        public string Title {get; set;}
        public string Author {get;set;}
        public string Publisher{get;set;}
        public BookSearchObject(string title, string author, string publisher)
        {
            Title= title;
            Author =author;
            Publisher =publisher;
        }
    }
}