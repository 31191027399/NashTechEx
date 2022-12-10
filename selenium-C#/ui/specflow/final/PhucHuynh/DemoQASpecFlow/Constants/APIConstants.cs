using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQASpecFlow.Constants
{
    public class APIConstants
    {
      public const string loginEndPath ="/Account/v1/Login";
      public const string deleteAllBooksEndPath ="/BookStore/v1/Books?UserId=";
      public const string getAllBooksEnPath ="/BookStore/v1/Books";
      public const string addBookToCollectionEndPath = "/BookStore/v1/Books";

    }
}