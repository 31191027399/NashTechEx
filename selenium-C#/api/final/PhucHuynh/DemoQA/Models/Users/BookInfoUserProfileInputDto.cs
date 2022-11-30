using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQA.Models.Users
{
    public class BookInfoInUserProfileInputDto
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string Publish_date { get; set; }
        public string Publisher { get; set; }
        public string Pages { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public BookInfoInUserProfileInputDto(string isbn, string title, string subTitle, string author, string publish_date, string publisher, string pages, string description, string website)
        {
            Isbn = isbn;
            Title = title;
            SubTitle = subTitle;
            Author = author;
            Publish_date = publish_date;
            Publisher = publisher;
            Pages = pages;
            Description = description;
            Website =website;
        }
    }

}