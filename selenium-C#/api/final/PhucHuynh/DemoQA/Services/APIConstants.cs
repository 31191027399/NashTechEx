using System.IO;
using System;
using System.Collections.Generic;
using DemoQA.Library;

namespace DemoQA.Services
{
    public class APIConstants
    {
        public const string Website = "https://demoqa.com";
        public const string getTokenEndpoint = "https://demoqa.com/Account/v1/GenerateToken";
        public const string userEndPoint = Website + "/Account/v1/User/";
        public const string bookEndPoint = Website + "/BookStore/v1/Books";
        public const string deleteBookEndPoint = Website + "/BookStore/v1/Book";
        public const string deleteAllBookEndPoint = Website + "/BookStore/v1/Books?UserId=";

        public const string BookInfoSchema = "Resources/Schema/replacebookschema.json";
    }
}